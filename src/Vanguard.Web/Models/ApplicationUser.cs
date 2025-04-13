using Microsoft.AspNetCore.Identity;

namespace Vanguard.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Adding custom properties for Members
        public required string DisplayName { get; set; }
        public string? Location { get; set; }
        public string? TimeZone { get; set; }
    }
}
