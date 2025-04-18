using Vanguard.Web.Data;
using Vanguard.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Vanguard.Web.Services;
using Vanguard.Web.Config;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// Service Registration
// --------------------------------------------------

// MVC + Razor support
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// IHttpContextAccessor for localisation
builder.Services.AddHttpContextAccessor();

// Force lowercase URLs
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

// Supported cultures for localisation
var supportedCultures = new[] { "en-AU", "en-US", "fr-FR", "de-DE", "en-gb", "es-ES" };

// Configure localisation
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US"); // Default if nothing else is specified
    options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();

    // Use browser's Accept-Language header as the first culture hint
    options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
});
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddScoped<IUniverseDateService>(provider =>
{
    var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
    var requestCulture = httpContextAccessor.HttpContext?.Features
        .Get<IRequestCultureFeature>()?.RequestCulture?.Culture ?? CultureInfo.InvariantCulture;

    return new UniverseDateService(requestCulture);
});

// Configure custom global variables
builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("AppSettings"));

// Entity Framework DB context with MySQL (via Pomelo)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Identity setup with roles
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// Custom login path override
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";
});

var app = builder.Build();

// --------------------------------------------------
// Database Seeding
// --------------------------------------------------
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbInitializer.SeedRolesAndAdmin(services); // Seeds roles + master admin
}

// --------------------------------------------------
// Middleware Configuration
// --------------------------------------------------

// Localisation middleware
var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

// Error handling + HTTPS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseHttpsRedirection(); // only enabled outside dev to avoid local HTTPS config issues
}
else
{
    app.UseDeveloperExceptionPage(); // dev-specific error pages
}

// Static files (wwwroot)
app.UseStaticFiles();

// Routing system
app.UseRouting();

// Authentication & Authorisation
app.UseAuthentication();
app.UseAuthorization();

// Static asset mapping
app.MapStaticAssets();

// Razor Pages support
app.MapRazorPages();

// --------------------------------------------------
// Route Mapping
// --------------------------------------------------

// 1. AREA ROUTES FIRST — matches /Admin/Controller/Action, avoids being swallowed by the default route
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

// 2. DEFAULT ROUTE LAST — catches everything else (fallback)
// Must come AFTER area routes or it will prevent them from working
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();