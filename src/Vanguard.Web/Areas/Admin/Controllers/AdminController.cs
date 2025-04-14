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

        public IActionResult ManageUniverses() => View();

        public IActionResult ManageFactions() => View();

        public IActionResult ManageBranches() => View();

        public IActionResult ManagePositionTypes() => View();

        public IActionResult ManageSpecies() => View();

        public IActionResult ManageGenders() => View();
    }
} 