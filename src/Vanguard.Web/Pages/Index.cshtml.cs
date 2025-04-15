using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vanguard.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("GlobalAdmin"))
                {
                    return Redirect("/admin");
                }

                return RedirectToPage("/dashboard");
            }

            return Page();
        }
    }
}