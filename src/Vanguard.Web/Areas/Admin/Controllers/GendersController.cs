using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vanguard.Web.Data;
using Vanguard.Web.Models;

namespace Vanguard.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "GlobalAdmin")]
    [Route("admin/genders")] // Base path for all actions in this controller
    public class GendersController : Controller
    {
        private readonly AppDbContext _context;

        public GendersController(AppDbContext context)
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

            return View("ManageGenders", genders);
        }


        [HttpGet("editgender/{id}")]
        public IActionResult EditGender(int id)
        {
            var gender = _context.Genders
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (gender == null)
                return NotFound();

            return PartialView("_EditGenderModal", gender);
        }

        [HttpPost("editgender")]
        [ValidateAntiForgeryToken]
        public IActionResult EditGender(Gender gender)
        {
            if (ModelState.IsValid)
            {
                var existing = _context.Genders
                    .IgnoreQueryFilters()
                    .FirstOrDefault(g => g.Id == gender.Id);
                if (existing == null)
                    return NotFound();

                existing.Name = gender.Name;
                existing.Description = gender.Description;

                _context.SaveChanges();
                return Ok(); // <- Return HTTP 200
            }

            // Return the modal with validation messages
            return BadRequest(PartialView("_EditGenderModal", gender));
        }

        [HttpGet("creategender")]
        public IActionResult CreateGender()
        {
            return PartialView("_CreateGenderModal", new Gender { Name = "" });
        }

        [HttpPost("creategender")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGender(Gender gender)
        {
            if (ModelState.IsValid)
            {
                gender.IsActive = true;

                // Include inactive records for correct DisplayOrder calculation
                var maxDisplayOrder = _context.Genders
                    .IgnoreQueryFilters()
                    .Any()
                    ? _context.Genders
                        .IgnoreQueryFilters()
                        .Max(g => g.DisplayOrder)
                    : 0;

                gender.DisplayOrder = maxDisplayOrder + 1;

                _context.Genders.Add(gender);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest(PartialView("_CreateGenderModal", gender));
        }

        [HttpGet("disablegender/{id}")]
        public IActionResult DisableGender(int id)
        {
            var gender = _context.Genders
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (gender == null)
                return NotFound();

            return PartialView("_DisableGenderModal", gender);
        }

        [HttpPost("disablegender")]
        [ValidateAntiForgeryToken]
        public IActionResult DisableGenderConfirmed(int id)
        {
            var gender = _context.Genders
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (gender == null)
                return NotFound();

            gender.IsActive = false;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("reenablegender")]
        [ValidateAntiForgeryToken]
        public IActionResult ReenableGender(int id)
        {
            var gender = _context.Genders
                .IgnoreQueryFilters()
                .FirstOrDefault(g => g.Id == id);
            if (gender == null)
                return NotFound();

            gender.IsActive = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}