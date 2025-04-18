using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vanguard.Web.Data;
using Vanguard.Web.Models;

namespace Vanguard.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "GlobalAdmin")]
    [Route("admin/branches")] // Base path for all actions in this controller
    public class BranchesController : Controller
    {
        private readonly AppDbContext _context;

        public BranchesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var branches = _context.Branches
                .IgnoreQueryFilters()
                .Include(s => s.Universe)
                .Include(s => s.Faction)
                .OrderBy(s => s.DisplayOrder)
                .ToList();

            return View("ManageBranches", branches);
        }
    }
}