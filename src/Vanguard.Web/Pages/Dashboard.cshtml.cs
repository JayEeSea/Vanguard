using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vanguard.Web.Models;
using Microsoft.Extensions.Localization;

namespace Vanguard.Web.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IStringLocalizer<DashboardModel> _localizer;

    public DashboardModel(UserManager<ApplicationUser> userManager, IStringLocalizer<DashboardModel> localizer)
    {
        _userManager = userManager;
        _localizer = localizer;
    }

    public string? DisplayName { get; set; }
    public string? LocalTimeString { get; set; }

    public string WelcomeText => _localizer["Welcome"];
    public string TimeLabel => _localizer["LocalTime"];

    public async Task OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        DisplayName = user?.DisplayName ?? "User";

        if (!string.IsNullOrWhiteSpace(user?.TimeZone))
        {
            try
            {
                var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(user.TimeZone);
                var now = TimeZoneInfo.ConvertTime(DateTime.UtcNow, userTimeZone);
                LocalTimeString = now.ToString("f", CultureInfo.CurrentCulture);
            }
            catch
            {
                LocalTimeString = "Unknown time zone.";
            }
        }
        else
        {
            LocalTimeString = "No time zone set.";
        }
    }
}

}
