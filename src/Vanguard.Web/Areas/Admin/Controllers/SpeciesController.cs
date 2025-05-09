using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vanguard.Web.Data;
using Vanguard.Web.Models;

namespace Vanguard.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "GlobalAdmin")]
    [Route("admin/species")] // Base path for all actions in this controller
    public class SpeciesController : Controller
    {
        private readonly AppDbContext _context;

        public SpeciesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var species = _context.Species
                .IgnoreQueryFilters()
                .Include(s => s.Universe)
                .Include(s => s.Faction)
                .Include(s => s.CanonicalSpecies)
                .OrderBy(s => s.DisplayOrder)
                .ToList();

            return View("ManageSpecies", species);
        }

        [HttpGet("createspecies")]
        public IActionResult CreateSpecies()
        {
            ViewBag.Universes = _context.Universes.OrderBy(u => u.DisplayOrder).ToList();
            ViewBag.Factions = _context.Factions.OrderBy(f => f.DisplayOrder).ToList();
            ViewBag.CanonicalSpecies = _context.Species
                .Where(s => s.UniverseId == null && s.FactionId == null) // Optional: only global species
                .OrderBy(s => s.DisplayOrder)
                .ToList();

            return PartialView("_CreateSpeciesModal", new Species { Name = "" });
        }

        [HttpPost("createspecies")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSpecies(Species species)
        {
            if (ModelState.IsValid)
            {
                species.IsActive = true;

                var maxDisplayOrder = _context.Species
                    .IgnoreQueryFilters()
                    .Any()
                    ? _context.Species
                        .IgnoreQueryFilters()
                        .Max(s => s.DisplayOrder)
                    : 0;

                species.DisplayOrder = maxDisplayOrder + 1;

                _context.Species.Add(species);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest(PartialView("_CreateSpeciesModal", species));
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

        [HttpGet("disablespecies/{id}")]
        public IActionResult DisableSpecies(int id)
        {
            var species = _context.Species
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (species == null)
                return NotFound();

            return PartialView("_DisableSpeciesModal", species);
        }

        [HttpPost("disablespecies")]
        [ValidateAntiForgeryToken]
        public IActionResult DisableSpeciesConfirmed(int id)
        {
            var species = _context.Species
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (species == null)
                return NotFound();

            species.IsActive = false;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("reenablespecies")]
        [ValidateAntiForgeryToken]
        public IActionResult ReenableSpecies(int id)
        {
            var species = _context.Species
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (species == null)
                return NotFound();

            species.IsActive = true;
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("editspecies/{id}")]
        public IActionResult EditSpecies(int id)
        {
            var species = _context.Species
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (species == null)
                return NotFound();

            ViewBag.Universes = _context.Universes.OrderBy(u => u.DisplayOrder).ToList();
            ViewBag.Factions = _context.Factions.OrderBy(f => f.DisplayOrder).ToList();
            ViewBag.CanonicalSpecies = _context.Species
                .Where(s => s.UniverseId == null && s.FactionId == null)
                .OrderBy(s => s.DisplayOrder)
                .ToList();

            return PartialView("_EditSpeciesModal", species);
        }

        [HttpPost("editspecies")]
        [ValidateAntiForgeryToken]
        public IActionResult EditSpecies(Species species)
        {
            if (ModelState.IsValid)
            {
                var existing = _context.Species
                    .IgnoreQueryFilters()
                    .FirstOrDefault(g => g.Id == species.Id);
                if (existing == null)
                    return NotFound();

                existing.Name = species.Name;
                existing.Description = species.Description;
                existing.UniverseId = species.UniverseId;
                existing.FactionId = species.FactionId;
                existing.CanonicalSpeciesId = species.CanonicalSpeciesId;

                _context.SaveChanges();
                return Ok();
            }

            // Repopulate dropdowns before returning modal with validation errors
            ViewBag.Universes = _context.Universes.OrderBy(u => u.DisplayOrder).ToList();
            ViewBag.Factions = _context.Factions.OrderBy(f => f.DisplayOrder).ToList();
            ViewBag.CanonicalSpecies = _context.Species
                .Where(s => s.UniverseId == null && s.FactionId == null)
                .OrderBy(s => s.DisplayOrder)
                .ToList();

            return BadRequest(PartialView("_EditSpeciesModal", species));
        }
    }
}