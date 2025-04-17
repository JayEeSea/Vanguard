using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vanguard.Web.Data;
using Vanguard.Web.Models;

namespace Vanguard.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "GlobalAdmin")]
    [Route("admin/ranks")] // Base path for all actions in this controller
    public class RanksController : Controller
    {
        private readonly AppDbContext _context;

        public RanksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var ranks = _context.Ranks
                .Include(s => s.Universe)
                .Include(s => s.Faction)
                .OrderBy(s => s.DisplayOrder)
                .ToList();

            return View("ManageRanks", ranks);
        }

        [HttpGet("disableranks/{id}")]
        public IActionResult DisableRank(int id)
        {
            var ranks = _context.Ranks
                .FirstOrDefault(g => g.Id == id);
            if (ranks == null)
                return NotFound();

            return PartialView("_DisableRanksModal", ranks);
        }

        [HttpPost("disableranks")]
        [ValidateAntiForgeryToken]
        public IActionResult DisableRankConfirmed(int id)
        {
            var ranks = _context.Ranks
                .FirstOrDefault(g => g.Id == id);
            if (ranks == null)
                return NotFound();

            ranks.IsActive = false;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("reenableranks")]
        [ValidateAntiForgeryToken]
        public IActionResult ReenableRank(int id)
        {
            var ranks = _context.Ranks
                .FirstOrDefault(g => g.Id == id);
            if (ranks == null)
                return NotFound();

            ranks.IsActive = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
