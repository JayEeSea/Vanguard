using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vanguard.Web.Models;

namespace Vanguard.Web.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Universe> Universes { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}