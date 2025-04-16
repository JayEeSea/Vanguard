using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Vanguard.Web.Config;
using Vanguard.Web.Data;
using Vanguard.Web.Models;
using Vanguard.Web.Services;

namespace Vanguard.Web.Controllers;

public class HomeController : Controller
{
    private readonly IUniverseDateService _universeDateService;
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(
        AppDbContext context,
        IUniverseDateService universeDateService,
        ILogger<HomeController> logger)
    {
        _context = context;
        _universeDateService = universeDateService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
