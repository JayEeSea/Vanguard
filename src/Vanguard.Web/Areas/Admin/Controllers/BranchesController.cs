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

        [HttpGet("disablebranches/{id}")]
        public IActionResult DisableFaction(int id)
        {
            var branches = _context.Branches
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (branches == null)
                return NotFound();

            return PartialView("_DisableBranchesModal", branches);
        }

        [HttpPost("disablebranches")]
        [ValidateAntiForgeryToken]
        public IActionResult DisableFactionConfirmed(int id)
        {
            var branches = _context.Branches
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (branches == null)
                return NotFound();

            branches.IsActive = false;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("reenablebranches")]
        [ValidateAntiForgeryToken]
        public IActionResult ReenableFaction(int id)
        {
            var branches = _context.Branches
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (branches == null)
                return NotFound();

            branches.IsActive = true;
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("createbranches")]
        public IActionResult CreateBranch()
        {
            ViewBag.Universes = _context.Universes.OrderBy(u => u.DisplayOrder).ToList();
            ViewBag.Factions = _context.Factions.OrderBy(f => f.DisplayOrder).ToList();

            return PartialView("_CreateBranchesModal", new Branch { Name = "" });
        }

        [HttpPost("createbranches")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBranches(Branch branches)
        {
            if (ModelState.IsValid)
            {
                branches.IsActive = true;

                var maxDisplayOrder = _context.Branches
                    .IgnoreQueryFilters()
                    .Any()
                    ? _context.Branches
                        .IgnoreQueryFilters()
                        .Max(s => s.DisplayOrder)
                    : 0;

                branches.DisplayOrder = maxDisplayOrder + 1;

                _context.Branches.Add(branches);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest(PartialView("_EditBranchesModal", branches));
        }

        [HttpGet("getfactions/{universeId}")]
        public IActionResult GetFactions(int universeId)
        {
            var factions = _context.Factions
                .Where(f => f.UniverseId == universeId)
                .OrderBy(f => f.DisplayOrder)
                .Select(f => new { f.Id, f.Name })
                .ToList();

            return Json(factions);
        }

        [HttpGet("editbranches/{id}")]
        public IActionResult EditBranch(int id)
        {
            var branch = _context.Branches
                .IgnoreQueryFilters()
                .FirstOrDefault(b => b.Id == id);
            if (branch == null)
                return NotFound();

            ViewBag.Universes = _context.Universes.OrderBy(u => u.DisplayOrder).ToList();
            ViewBag.Factions = _context.Factions.OrderBy(f => f.DisplayOrder).ToList();

            return PartialView("_EditBranchesModal", branch);
        }

        [HttpPost("editbranches")]
        [ValidateAntiForgeryToken]
        public IActionResult EditBranches(Branch updated)
        {
            if (ModelState.IsValid)
            {
                var existing = _context.Branches
                    .IgnoreQueryFilters()
                    .FirstOrDefault(b => b.Id == updated.Id);

                if (existing == null)
                    return NotFound();

                existing.Name = updated.Name;
                existing.Description = updated.Description;
                existing.UniverseId = updated.UniverseId;
                existing.FactionId = updated.FactionId;
                existing.IsActive = true;
                // Keep existing.DisplayOrder as-is, or allow updating it if needed

                _context.SaveChanges();
                return Ok();
            }

            // Rebind dropdowns in case of validation error
            ViewBag.Universes = _context.Universes.OrderBy(u => u.DisplayOrder).ToList();
            ViewBag.Factions = _context.Factions.OrderBy(f => f.DisplayOrder).ToList();

            return BadRequest(PartialView("_EditBranchesModal", updated));
        }

    }
}
