using Microsoft.AspNetCore.Mvc;
using Vanguard.Web.Data;
using Vanguard.Web.Services;

namespace Vanguard.Web.ViewComponents
{
    public class InCharacterDateViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IUniverseDateService _universeDateService;

        public InCharacterDateViewComponent(
            AppDbContext context,
            IUniverseDateService universeDateService)
        {
            _context = context;
            _universeDateService = universeDateService;
        }

        public IViewComponentResult Invoke()
        {
            var activeUniverses = _context.Universes
                .Where(u => u.IsActive)
                .OrderBy(u => u.DisplayOrder)
                .ToList();

            var dateEntries = activeUniverses
                .Select(u => new UniverseDateEntry
                {
                    UniverseName = u.Name,
                    DisplayDate = _universeDateService.GetInCharacterDate(u)
                })
                .ToList();

            return View("Default", dateEntries);
        }

        public class UniverseDateEntry
        {
            public string UniverseName { get; set; } = string.Empty;
            public string DisplayDate { get; set; } = string.Empty;
        }
    }
}