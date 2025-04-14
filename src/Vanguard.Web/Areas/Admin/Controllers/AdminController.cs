using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vanguard.Web.Data;

namespace Vanguard.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "GlobalAdmin")]
    [Route("admin")] // Base path for all actions in this controller
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index() => View();

        [HttpGet("manageranks")]
        public IActionResult ManageRanks() => View();

        [HttpGet("managepositions")]
        public IActionResult ManagePositions() => View();

        [HttpGet("manageunits")]
        public IActionResult ManageUnits() => View();

        [HttpGet("manageuniverses")]
        public IActionResult ManageUniverses() => View();

        [HttpGet("managefactions")]
        public IActionResult ManageFactions() => View();

        [HttpGet("managebranches")]
        public IActionResult ManageBranches() => View();

        [HttpGet("managepositiontypes")]
        public IActionResult ManagePositionTypes() => View();

        [HttpGet("managespecies")]
        public IActionResult ManageSpecies() => View();

        [HttpGet("managegenders")]
        public IActionResult ManageGenders()
        {
            var genders = _context.Genders
                .OrderBy(g => g.DisplayOrder)
                .ToList();

            return View(genders);
        }
    }
}
