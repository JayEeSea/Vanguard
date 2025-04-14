using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vanguard.Web.Data;
using Vanguard.Web.Models;

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
    }
}