using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Vanguard.Web.Data;
using Vanguard.Web.Models;

namespace Vanguard.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "GlobalAdmin")]
    [Route("admin/units")] // Base path for all actions in this controller
    public class UnitsController : Controller
    {
        private readonly AppDbContext _context;

        public UnitsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index(int? branchId, bool showGlobal = false)
        {
            var query = _context.Units
                .IgnoreQueryFilters()
                .Include(r => r.Universe)
                .Include(r => r.Faction)
                .Include(r => r.Branch)
                .Include(r => r.ParentUnit)
                .AsQueryable();

            if (branchId.HasValue)
            {
                query = query.Where(u => u.BranchId == branchId.Value);
            }

            if (showGlobal)
            {
                // Apply your logic for "global" units.
                // This assumes global = UniverseId == null && FactionId == null && BranchId == null
                query = query.Where(u => u.UniverseId == null && u.FactionId == null && u.BranchId == null);
            }

            var units = query
                .OrderBy(s => s.DisplayOrder)
                .ToList();

            ViewBag.Branches = _context.Branches.OrderBy(b => b.Name).ToList();
            ViewBag.SelectedBranchId = branchId;
            ViewBag.ShowGlobal = showGlobal;
            ViewBag.HasFiltered = showGlobal || branchId.HasValue;

            return View("ManageUnits", units);
        }

        [HttpGet("disableunits/{id}")]
        public IActionResult DisableUnits(int id)
        {
            var units = _context.Universes
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (units == null)
                return NotFound();

            return PartialView("_DisableUnitsModal", units);
        }

        [HttpPost("disableunits")]
        [ValidateAntiForgeryToken]
        public IActionResult DisableUnitsConfirmed(int id)
        {
            var units = _context.Units
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (units == null)
                return NotFound();

            units.IsActive = false;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("reenableunits")]
        [ValidateAntiForgeryToken]
        public IActionResult ReenableUnits(int id)
        {
            var units = _context.Units
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (units == null)
                return NotFound();

            units.IsActive = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
