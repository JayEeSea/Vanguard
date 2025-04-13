using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vanguard.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "GlobalAdmin")]
    public class AdminController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult ManageRanks() => View();

        public IActionResult ManagePositions() => View();

        public IActionResult ManageUnits() => View();
    }
} 