using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Vanguard.Web.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class CharactersModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
