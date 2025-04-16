using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Vanguard.Web.Data;
using Vanguard.Web.Models;

namespace Vanguard.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "GlobalAdmin")]
    [Route("admin/factions")] // Base path for all actions in this controller
    public class FactionsController : Controller
    {
        private readonly AppDbContext _context;

        public FactionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var factions = _context.Factions
                .IgnoreQueryFilters()
                .Include(s => s.Universe)
                .OrderBy(s => s.DisplayOrder)
                .ToList();

            return View("ManageFactions", factions);
        }

        [HttpGet("disablefactions/{id}")]
        public IActionResult DisableFaction(int id)
        {
            var factions = _context.Factions
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (factions == null)
                return NotFound();

            return PartialView("_DisableFactionsModal", factions);
        }

        [HttpPost("disablefactions")]
        [ValidateAntiForgeryToken]
        public IActionResult DisableFactionConfirmed(int id)
        {
            var factions = _context.Factions
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (factions == null)
                return NotFound();

            factions.IsActive = false;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("reenablefactions")]
        [ValidateAntiForgeryToken]
        public IActionResult ReenableFaction(int id)
        {
            var factions = _context.Factions
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (factions == null)
                return NotFound();

            factions.IsActive = true;
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("createfactions")]
        public IActionResult CreateFaction()
        {
            ViewBag.Universes = _context.Universes.OrderBy(u => u.DisplayOrder).ToList();

            return PartialView("_CreateFactionsModal", new Faction { Name = "" });
        }

        [HttpPost("createfactions")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFaction(Faction factions)
        {
            if (ModelState.IsValid)
            {
                factions.IsActive = true;

                var maxDisplayOrder = _context.Factions
                    .IgnoreQueryFilters()
                    .Any()
                    ? _context.Factions
                        .IgnoreQueryFilters()
                        .Max(s => s.DisplayOrder)
                    : 0;

                factions.DisplayOrder = maxDisplayOrder + 1;

                _context.Factions.Add(factions);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest(PartialView("_CreateFactionsModal", factions));
        }

        [HttpGet("getuniverses/{universeId}")]
        public IActionResult GetUniverses(int universeId)
        {
            var universes = _context.Universes
                .Where(f => f.Id == universeId)
                .OrderBy(f => f.DisplayOrder)
                .Select(f => new { f.Id, f.Name })
                .ToList();

            return Json(universes);
        }

        [HttpGet("editfactions/{id}")]
        public IActionResult EditFactions(int id)
        {
            var factions = _context.Factions
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (factions == null)
                return NotFound();

            ViewBag.Universes = _context.Universes.OrderBy(u => u.DisplayOrder).ToList();

            return PartialView("_EditFactionsModal", factions);
        }

        [HttpPost("editfactions")]
        [ValidateAntiForgeryToken]
        public IActionResult EditFactions(Faction factions)
        {
            if (ModelState.IsValid)
            {
                var existing = _context.Factions
                    .IgnoreQueryFilters()
                    .FirstOrDefault(f => f.Id == factions.Id);

                if (existing == null)
                    return NotFound();

                // If UniverseId is changing, check for DisplayOrder conflict
                if (existing.UniverseId != factions.UniverseId)
                {
                    bool displayOrderConflict = _context.Factions
                        .IgnoreQueryFilters()
                        .Any(f => f.UniverseId == factions.UniverseId &&
                                  f.DisplayOrder == existing.DisplayOrder &&
                                  f.Id != existing.Id);

                    if (displayOrderConflict)
                    {
                        ModelState.AddModelError("", "Another faction in the selected universe already uses this display order.");
                        ViewBag.Universes = _context.Universes.OrderBy(u => u.DisplayOrder).ToList();
                        return BadRequest(PartialView("_EditFactionsModal", factions));
                    }
                }

                // Update fields
                existing.Name = factions.Name;
                existing.Description = factions.Description;
                existing.UniverseId = factions.UniverseId;

                _context.SaveChanges();
                return Ok();
            }

            // Repopulate dropdowns if validation fails
            ViewBag.Universes = _context.Universes.OrderBy(u => u.DisplayOrder).ToList();
            return BadRequest(PartialView("_EditFactionsModal", factions));
        }
    }
}
