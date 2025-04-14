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
            var genders = _context.Genders
                .IgnoreQueryFilters()
                .OrderBy(g => g.DisplayOrder)
                .ToList();

            return View("ManageSpecies", genders);
        }

        [HttpGet("managespecies")]
        public IActionResult ManageSpecies()
        {
            var species = _context.Species
                .IgnoreQueryFilters()
                .Include(s => s.Universe)
                .Include(s => s.Faction)
                .Include(s => s.CanonicalSpecies)
                .OrderBy(s => s.DisplayOrder)
                .ToList();

            return View(species);
        }

        [HttpGet("createspecies")]
        public IActionResult CreateSpecies()
        {
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
    }
}