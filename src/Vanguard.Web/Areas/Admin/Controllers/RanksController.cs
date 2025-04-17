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
    [Route("admin/ranks")]
    public class RanksController : Controller
    {
        private readonly AppDbContext _context;

        public RanksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index(int? branchId, string? showGlobal)
        {
            var query = _context.Ranks
                .IgnoreQueryFilters()
                .Include(r => r.Universe)
                .Include(r => r.Faction)
                .Include(r => r.Branch)
                .AsQueryable();

            bool isShowGlobal = !string.IsNullOrEmpty(showGlobal);

            if (isShowGlobal)
            {
                query = query.Where(r => r.UniverseId == null && r.FactionId == null && r.BranchId == null);
            }
            else if (branchId.HasValue)
            {
                query = query.Where(r => r.BranchId == branchId.Value);
            }

            var ranks = query
                .OrderBy(r => r.DisplayOrder)
                .ToList();

            ViewBag.Branches = _context.Branches.OrderBy(b => b.Name).ToList();
            ViewBag.SelectedBranchId = branchId;
            ViewBag.ShowGlobal = isShowGlobal;
            ViewBag.HasFiltered = !string.IsNullOrEmpty(showGlobal) || branchId.HasValue;

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
