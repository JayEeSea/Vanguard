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
    }
}
