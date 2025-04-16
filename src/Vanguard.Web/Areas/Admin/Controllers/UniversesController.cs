using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vanguard.Web.Data;
using Vanguard.Web.Models;

namespace Vanguard.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "GlobalAdmin")]
    [Route("admin/universes")] // Base path for all actions in this controller
    public class UniversesController : Controller
    {
        private readonly AppDbContext _context;

        public UniversesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var universes = _context.Universes
                .IgnoreQueryFilters()
                .OrderBy(s => s.DisplayOrder)
                .ToList();

            return View("ManageUniverses", universes);
        }

        [HttpGet("disableuniverses/{id}")]
        public IActionResult DisableUniverses(int id)
        {
            var universes = _context.Universes
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (universes == null)
                return NotFound();

            return PartialView("_DisableUniversesModal", universes);
        }

        [HttpPost("disableuniverses")]
        [ValidateAntiForgeryToken]
        public IActionResult DisableUniversesConfirmed(int id)
        {
            var universes = _context.Universes
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (universes == null)
                return NotFound();

            universes.IsActive = false;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("reenableuniverses")]
        [ValidateAntiForgeryToken]
        public IActionResult ReenableUniverses(int id)
        {
            var universes = _context.Universes
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (universes == null)
                return NotFound();

            universes.IsActive = true;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("createuniverses")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUniverses(Universe universe)
        {
            if (ModelState.IsValid)
            {
                universe.IsActive = true;

                // Conditionally set BBYABYAnchorDate
                if (universe.UsesBBYABY && universe.BBYABYAnchorDate == null)
                {
                    universe.BBYABYAnchorDate = new DateTime(1977, 5, 25);
                }
                else if (!universe.UsesBBYABY)
                {
                    universe.BBYABYAnchorDate = null;
                }

                // Conditionally set StardateBaseDate (similar logic, if needed)
                if (!universe.EnableStardate)
                {
                    universe.StardateBaseDate = null;
                    universe.StardateMultiplier = null;
                    universe.UsesOffset = false;
                    universe.OffsetYears = null;
                }
                else if (!universe.UsesOffset)
                {
                    universe.OffsetYears = null;
                }

                // Find the next display order
                var maxDisplayOrder = _context.Universes
                    .IgnoreQueryFilters() // Include inactive
                    .Max(u => (int?)u.DisplayOrder) ?? 0;

                universe.DisplayOrder = maxDisplayOrder + 1;

                _context.Universes.Add(universe);
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest(PartialView("_CreateUniversesModal", universe));
        }

        [HttpGet("createuniverses")]
        public IActionResult CreateUniverses()
        {
            return PartialView("_CreateUniversesModal", new Universe
            {
                Name = "",
                Description = "",
                DisplayFormat = "",
                BBYABYAnchorDate = null,
                StardateBaseDate = null,
                OffsetYears = 0,
                StardateMultiplier = null
            });
        }

        [HttpGet("edituniverses/{id}")]
        public IActionResult EditUniverses(int id)
        {
            var universe = _context.Universes
                .IgnoreQueryFilters()
                .FirstOrDefault(u => u.Id == id);

            if (universe == null)
                return NotFound();

            return PartialView("_EditUniversesModal", universe);
        }

        [HttpPost("edituniverses")]
        [ValidateAntiForgeryToken]
        public IActionResult EditUniverses(Universe universe)
        {
            if (ModelState.IsValid)
            {
                var existing = _context.Universes
                    .IgnoreQueryFilters()
                    .FirstOrDefault(u => u.Id == universe.Id);

                if (existing == null)
                    return NotFound();

                // Update fields
                existing.Name = universe.Name;
                existing.Description = universe.Description;
                existing.DisplayFormat = universe.DisplayFormat;
                existing.UsesBBYABY = universe.UsesBBYABY;
                existing.BBYABYAnchorDate = universe.UsesBBYABY ? universe.BBYABYAnchorDate : null;
                existing.EnableStardate = universe.EnableStardate;
                existing.StardateBaseDate = universe.EnableStardate ? universe.StardateBaseDate : null;
                existing.StardateMultiplier = universe.EnableStardate ? universe.StardateMultiplier : null;
                existing.UsesOffset = universe.EnableStardate && universe.UsesOffset;
                existing.OffsetYears = (universe.EnableStardate && universe.UsesOffset) ? universe.OffsetYears : null;

                _context.SaveChanges();
                return Ok();
            }

            return BadRequest(PartialView("_EditUniversesModal", universe));
        }
    }
}
