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
        public DbSet<PositionType> PositionTypes { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Universe> Universes { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Unit>()
                .HasOne(u => u.ParentUnit)
                .WithMany(u => u.SubUnits)
                .HasForeignKey(u => u.ParentUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seeding Position Types
            builder.Entity<PositionType>().HasData(
                new PositionType { Id = 1, Name = "Universe Leader", RoleName = "UniverseLeader", Level = 1 },
                new PositionType { Id = 2, Name = "Faction Leader", RoleName = "FactionLeader", Level = 2 },
                new PositionType { Id = 3, Name = "Branch Leader", RoleName = "BranchLeader", Level = 3 },
                new PositionType { Id = 4, Name = "Unit Leader", RoleName = "UnitLeader", Level = 5 },
                new PositionType { Id = 5, Name = "SubUnit Leader", RoleName = "SubUnitLeader", Level = 6 },
                new PositionType { Id = 6, Name = "Command Staff", RoleName = "CommandStaff", Level = 0 },
                new PositionType { Id = 7, Name = "Command Staff Deputy", RoleName = "CommandStaffDeputy", Level = 1 },
                new PositionType { Id = 8, Name = "Command Staff Assistant", RoleName = "CommandStaffAssistant", Level = 2 },
                new PositionType { Id = 9, Name = "Branch Command", RoleName = "BranchCommand", Level = 4 },
                new PositionType { Id = 10, Name = "Member", RoleName = "Member", Level = 7 }
            );

            // Seeding Universes
            builder.Entity<Universe>().HasData(
            new Universe { Id = 1, Name = "Star Wars", Description = "A galaxy far, far away" },
            new Universe { Id = 2, Name = "Star Trek", Description = "The final frontier" }
            );

            // Seeding Factions, Branches, and Units
            builder.Entity<Faction>().HasData(
                new Faction { Id = 1, Name = "Galactic Empire", UniverseParentId = 1 },
                new Faction { Id = 2, Name = "Rebellion", UniverseParentId = 1 },
                new Faction { Id = 3, Name = "United Federation of Planets", UniverseParentId = 2 },
                new Faction { Id = 4, Name = "tlhIngan wo'", UniverseParentId = 2 }
            );

            builder.Entity<Branch>().HasData(
                new Branch { Id = 1, Name = "Imperial Navy", UniverseParentId = 1, FactionParentId = 1 },
                new Branch { Id = 2, Name = "Rebel Fleet", UniverseParentId = 1, FactionParentId = 2 },
                new Branch { Id = 3, Name = "Stormtrooper Legion", UniverseParentId = 1, FactionParentId = 1 },
                new Branch { Id = 4, Name = "Rebel Troopers", UniverseParentId = 1, FactionParentId = 2 },
                new Branch { Id = 5, Name = "Starfleet", UniverseParentId = 2, FactionParentId = 3 },
                new Branch { Id = 6, Name = "tlhIngan Hubbeq", UniverseParentId = 2, FactionParentId = 4 }
            );

            builder.Entity<Unit>().HasData(
                new Unit { Id = 1, Name = "ISD Devastator", UniverseId = 1, FactionId = 1, BranchId = 1 },
                new Unit { Id = 2, Name = "Red Squadron", UniverseId = 1, FactionId = 2, BranchId = 1, ParentUnitId = 1 },
                new Unit { Id = 3, Name = "USS Enterprise", UniverseId = 2, FactionId = 3, BranchId = 2 }
            );

            // Seeding Positions
            builder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Vanguard Commander", PositionTypeId = 6, Abbreviation = "VC", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 1, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 2, Name = "Vanguard Executive Officer", PositionTypeId = 6, Abbreviation = "VX", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 3, Name = "Vanguard Operations Officer", PositionTypeId = 6, Abbreviation = "VOO", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 4, Name = "Vanguard Engineering Officer", PositionTypeId = 6, Abbreviation = "VEO", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 5, Name = "Vanguard Training Officer", PositionTypeId = 6, Abbreviation = "VTO", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 6, Name = "Vanguard Intelligence Officer", PositionTypeId = 6, Abbreviation = "VIO", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 7, Name = "Vanguard Communications Officer", PositionTypeId = 6, Abbreviation = "VCO", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 8, Name = "Vanguard Science Officer", PositionTypeId = 6, Abbreviation = "VSCO", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 9, Name = "Vanguard Judge Advocate", PositionTypeId = 6, Abbreviation = "VJA", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 10, Name = "Star Wars Leader", PositionTypeId = 1, Abbreviation = "SWL", UniverseId = 1, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 11, Name = "Emperor", PositionTypeId = 2, Abbreviation = "EMP", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 12, Name = "Commander-in-chief, Imperial Navy", PositionTypeId = 3, Abbreviation = "CCIN", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 13, Name = "Imperial Personnel Officer", PositionTypeId = 9, Abbreviation = "IPO", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 14, Name = "Imperial Academy Commandant", PositionTypeId = 9, Abbreviation = "IAC", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 15, Name = "Fleet Commander", PositionTypeId = 4, Abbreviation = "FC", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 16, Name = "Taskforce Commander", PositionTypeId = 4, Abbreviation = "TFC", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 17, Name = "Ship Command Officer", PositionTypeId = 4, Abbreviation = "SCO", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 18, Name = "Wing Commander", PositionTypeId = 4, Abbreviation = "WC", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 19, Name = "Squadron Commander", PositionTypeId = 4, Abbreviation = "SQC", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 10, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 20, Name = "Squadron Flight Leader", PositionTypeId = 4, Abbreviation = "SFL", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 12, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 21, Name = "Squadron Member", PositionTypeId = 10, Abbreviation = "SM", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, MinRankLevel = 14, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 22, Name = "Legion Commander", PositionTypeId = 3, Abbreviation = "LEC", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 23, Name = "Stormtrooper Command 1", PositionTypeId = 9, Abbreviation = "SC1", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 24, Name = "Stormtrooper Command 2", PositionTypeId = 9, Abbreviation = "SC2", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 25, Name = "Sector Commander", PositionTypeId = 4, Abbreviation = "SEC", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 26, Name = "Battalion Commander", PositionTypeId = 4, Abbreviation = "BC", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 27, Name = "Company Commander", PositionTypeId = 4, Abbreviation = "CC", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 28, Name = "Assault Team Leader", PositionTypeId = 4, Abbreviation = "ATL", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, MinRankLevel = 11, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 29, Name = "Assault Team Executive Officer", PositionTypeId = 4, Abbreviation = "ATX", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, MinRankLevel = 12, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 30, Name = "Trooper", PositionTypeId = 10, Abbreviation = "MAR", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, MinRankLevel = 15, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 31, Name = "Chancellor of the Alliance", PositionTypeId = 2, Abbreviation = "COTA", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 32, Name = "Admiral of the Fleet", PositionTypeId = 3, Abbreviation = "AF", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 33, Name = "Rebel Fleet Command 1", PositionTypeId = 9, Abbreviation = "RFC1", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 34, Name = "Rebel Fleet Command 2", PositionTypeId = 9, Abbreviation = "RFC2", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 35, Name = "Fleet Commander", PositionTypeId = 4, Abbreviation = "FC", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 36, Name = "Taskforce Commander", PositionTypeId = 4, Abbreviation = "TFC", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 37, Name = "Commanding Officer", PositionTypeId = 4, Abbreviation = "CO", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 38, Name = "Executive Officer", PositionTypeId = 4, Abbreviation = "XO", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, MinRankLevel = 6, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 39, Name = "Department Head", PositionTypeId = 4, Abbreviation = "DH", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, MinRankLevel = 8, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 40, Name = "Officer", PositionTypeId = 10, Abbreviation = "OF", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, MinRankLevel = 10, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 41, Name = "Commanding General", PositionTypeId = 3, Abbreviation = "CGEN", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 42, Name = "Rebel Trooper Command 1", PositionTypeId = 9, Abbreviation = "RTC1", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 43, Name = "Rebel Trooper Command 2", PositionTypeId = 9, Abbreviation = "RTC2", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 44, Name = "Sector Division Commander", PositionTypeId = 4, Abbreviation = "SDC", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 45, Name = "Fleet Division Commander", PositionTypeId = 4, Abbreviation = "FDC", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 46, Name = "Brigade Leader", PositionTypeId = 4, Abbreviation = "BL", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 47, Name = "Company Leader", PositionTypeId = 4, Abbreviation = "CL", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, MinRankLevel = 8, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 48, Name = "Troop Leader", PositionTypeId = 4, Abbreviation = "TL", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, MinRankLevel = 11, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 49, Name = "Troop Deputy", PositionTypeId = 4, Abbreviation = "TD", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, MinRankLevel = 12, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 50, Name = "Solider", PositionTypeId = 10, Abbreviation = "SOL", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, MinRankLevel = 15, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 51, Name = "Star Trek Leader", PositionTypeId = 1, Abbreviation = "STL", UniverseId = 2, FactionId = null, BranchId = null, UnitId = null, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 52, Name = "President of the United Federation of Planets", PositionTypeId = 2, Abbreviation = "PRES", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 53, Name = "Chief of Starfleet Operations", PositionTypeId = 3, Abbreviation = "CSO", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 54, Name = "Chief of Starfleet Personnel and Training", PositionTypeId = 9, Abbreviation = "CSP", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 55, Name = "Chief of Starfleet Science and Exploration", PositionTypeId = 9, Abbreviation = "CSSE", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 56, Name = "Sector Commander", PositionTypeId = 4, Abbreviation = "SC", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 57, Name = "Fleet Commander", PositionTypeId = 4, Abbreviation = "FC", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 58, Name = "Taskforce Commander", PositionTypeId = 4, Abbreviation = "TFC", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 59, Name = "Commanding Officer", PositionTypeId = 4, Abbreviation = "CO", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 60, Name = "Executive Officer", PositionTypeId = 4, Abbreviation = "XO", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 8, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 61, Name = "Department Head", PositionTypeId = 4, Abbreviation = "DH", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 62, Name = "Officer", PositionTypeId = 10, Abbreviation = "OF", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, MinRankLevel = 12, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 63, Name = "paQ'dIj", PositionTypeId = 2, Abbreviation = "PAQ", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 64, Name = "Supreme Commander, tlhIngan Hubbeq", PositionTypeId = 3, Abbreviation = "SCTH", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 65, Name = "Personnel Officer, tlhIngan Hubbeq", PositionTypeId = 9, Abbreviation = "POTH", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 66, Name = "Battle Officer, tlhIngan Hubbeq", PositionTypeId = 9, Abbreviation = "BOTH", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 67, Name = "Fleet Commander", PositionTypeId = 4, Abbreviation = "FC", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 68, Name = "Taskgroup Commander", PositionTypeId = 4, Abbreviation = "TGC", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 69, Name = "Commanding Officer", PositionTypeId = 4, Abbreviation = "CO", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 70, Name = "Executive Officer", PositionTypeId = 4, Abbreviation = "XO", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, MinRankLevel = 8, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 71, Name = "Department Head", PositionTypeId = 4, Abbreviation = "DH", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null },
                new Position { Id = 72, Name = "Officer", PositionTypeId = 10, Abbreviation = "OF", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, MinRankLevel = 12, MaxRankLevel = 1, ImageUrl = null }
            );

            // Seeding Ranks
            builder.Entity<Rank>().HasData(
                new Rank { Id = 1, Name = "Grand Admiral", Abbreviation = "GA", UniverseId = null, FactionId = null, BranchId = null, Level = 1 },
                new Rank { Id = 2, Name = "Lord High Admiral", Abbreviation = "LHA", UniverseId = null, FactionId = null, BranchId = null, Level = 2 },
                new Rank { Id = 3, Name = "High Admiral", Abbreviation = "HADM", UniverseId = null, FactionId = null, BranchId = null, Level = 3 },
                new Rank { Id = 4, Name = "Fleet Admiral", Abbreviation = "FADM", UniverseId = null, FactionId = null, BranchId = null, Level = 4 },
                new Rank { Id = 5, Name = "Admiral", Abbreviation = "ADM", UniverseId = null, FactionId = null, BranchId = null, Level = 5 },
                new Rank { Id = 6, Name = "Vice Admiral", Abbreviation = "VADM", UniverseId = null, FactionId = null, BranchId = null, Level = 6 },
                new Rank { Id = 7, Name = "Rear Admiral", Abbreviation = "RADM", UniverseId = null, FactionId = null, BranchId = null, Level = 7 },
                new Rank { Id = 8, Name = "Fleet Admiral", Abbreviation = "FADM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 1 },
                new Rank { Id = 9, Name = "Admiral", Abbreviation = "ADM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 2 },
                new Rank { Id = 10, Name = "Vice Admiral", Abbreviation = "VADM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 3 },
                new Rank { Id = 11, Name = "Rear Admiral", Abbreviation = "RADM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 4 },
                new Rank { Id = 12, Name = "Commodore", Abbreviation = "COM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 5 },
                new Rank { Id = 13, Name = "Colonel", Abbreviation = "COL", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 6 },
                new Rank { Id = 14, Name = "Lieutenant Colonel", Abbreviation = "LTCOL", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 7 },
                new Rank { Id = 15, Name = "Major", Abbreviation = "MAJ", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 8 },
                new Rank { Id = 16, Name = "Captain", Abbreviation = "CPT", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 9 },
                new Rank { Id = 17, Name = "Commander", Abbreviation = "COM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 10 },
                new Rank { Id = 18, Name = "Lieutenant Commander", Abbreviation = "LTCOM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 11 },
                new Rank { Id = 19, Name = "Lieutenant", Abbreviation = "LT", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 12 },
                new Rank { Id = 20, Name = "Sub-Lieutenant", Abbreviation = "SLT", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 13 },
                new Rank { Id = 21, Name = "Ensign", Abbreviation = "ENS", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 14 },
                new Rank { Id = 22, Name = "Legion General", Abbreviation = "LEGEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 1 },
                new Rank { Id = 23, Name = "High General", Abbreviation = "HGEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 2 },
                new Rank { Id = 24, Name = "General", Abbreviation = "GEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 3 },
                new Rank { Id = 25, Name = "Lieutenant General", Abbreviation = "LGEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 4 },
                new Rank { Id = 26, Name = "Major General", Abbreviation = "MGEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 5 },
                new Rank { Id = 27, Name = "Brigadier General", Abbreviation = "BGEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 6 },
                new Rank { Id = 28, Name = "Colonel", Abbreviation = "COL", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 7 },
                new Rank { Id = 29, Name = "Lieutenant Colonel", Abbreviation = "LTCOL", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 8 },
                new Rank { Id = 30, Name = "Major", Abbreviation = "MAJ", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 9 },
                new Rank { Id = 31, Name = "Captain", Abbreviation = "CPT", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 10 },
                new Rank { Id = 32, Name = "First Lieutenant", Abbreviation = "1LT", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 11 },
                new Rank { Id = 33, Name = "Second Lieutenant", Abbreviation = "2LT", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 12 },
                new Rank { Id = 34, Name = "Sergeant", Abbreviation = "SGT", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 13 },
                new Rank { Id = 35, Name = "Corporal", Abbreviation = "CPL", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 14 },
                new Rank { Id = 36, Name = "Private", Abbreviation = "PVT", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 15 },
                new Rank { Id = 37, Name = "Admiral", Abbreviation = "ADM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 1 },
                new Rank { Id = 38, Name = "Vice Admiral", Abbreviation = "VADM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 2 },
                new Rank { Id = 39, Name = "Rear Admiral", Abbreviation = "RADM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 3 },
                new Rank { Id = 40, Name = "Commodore", Abbreviation = "COM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 4 },
                new Rank { Id = 41, Name = "Captain", Abbreviation = "CPT", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 5 },
                new Rank { Id = 42, Name = "Commander", Abbreviation = "COM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 6 },
                new Rank { Id = 43, Name = "Lieutenant Commander", Abbreviation = "LTCOM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 7 },
                new Rank { Id = 44, Name = "Lieutenant", Abbreviation = "LT", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 8 },
                new Rank { Id = 45, Name = "Lieutenant Junior Grade", Abbreviation = "LTJG", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 9 },
                new Rank { Id = 46, Name = "Ensign", Abbreviation = "ENS", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 10 },
                new Rank { Id = 47, Name = "Trooper General", Abbreviation = "TGEN", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 2 },
                new Rank { Id = 48, Name = "General", Abbreviation = "GEN", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 3 },
                new Rank { Id = 49, Name = "Lieutenant General", Abbreviation = "LGEN", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 4 },
                new Rank { Id = 50, Name = "Major General", Abbreviation = "MGEN", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 5 },
                new Rank { Id = 51, Name = "Brigadier General", Abbreviation = "BGEN", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 6 },
                new Rank { Id = 52, Name = "Colonel", Abbreviation = "COL", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 7 },
                new Rank { Id = 53, Name = "Lieutenant Colonel", Abbreviation = "LTCOL", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 8 },
                new Rank { Id = 54, Name = "Major", Abbreviation = "MAJ", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 9 },
                new Rank { Id = 55, Name = "Captain", Abbreviation = "CPT", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 10 },
                new Rank { Id = 56, Name = "Lieutenant", Abbreviation = "LT", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 11 },
                new Rank { Id = 57, Name = "Officer Cadet", Abbreviation = "OC", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 12 },
                new Rank { Id = 58, Name = "Sergeant", Abbreviation = "SGT", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 13 },
                new Rank { Id = 59, Name = "Corporal", Abbreviation = "CPL", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 14 },
                new Rank { Id = 60, Name = "Private", Abbreviation = "PVT", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 15 },
                new Rank { Id = 61, Name = "Fleet Admiral", Abbreviation = "FADM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 1 },
                new Rank { Id = 62, Name = "Admiral", Abbreviation = "ADM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 2 },
                new Rank { Id = 63, Name = "Vice Admiral", Abbreviation = "VADM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 3 },
                new Rank { Id = 64, Name = "Rear Admiral", Abbreviation = "RADM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 4 },
                new Rank { Id = 65, Name = "Commodore", Abbreviation = "COM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 5 },
                new Rank { Id = 66, Name = "Captain", Abbreviation = "CPT", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 6 },
                new Rank { Id = 67, Name = "Commander", Abbreviation = "COM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 7 },
                new Rank { Id = 68, Name = "Lieutenant Commander", Abbreviation = "LTCOM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 8 },
                new Rank { Id = 69, Name = "Lieutenant", Abbreviation = "LT", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 9 },
                new Rank { Id = 70, Name = "Lieutenant Junior Grade", Abbreviation = "LTJG", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 10 },
                new Rank { Id = 71, Name = "Ensign", Abbreviation = "ENS", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 11 },
                new Rank { Id = 72, Name = "Cadet", Abbreviation = "CDT", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 12 },
                new Rank { Id = 73, Name = "'ajyo'", Abbreviation = "AJYO", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 1 },
                new Rank { Id = 74, Name = "'aj", Abbreviation = "AJ", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 2 },
                new Rank { Id = 75, Name = "totlh", Abbreviation = "TOT", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 3 },
                new Rank { Id = 76, Name = "HoDghom", Abbreviation = "HODG", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 4 },
                new Rank { Id = 77, Name = "HoDyo'", Abbreviation = "HODY", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 5 },
                new Rank { Id = 78, Name = "HoD", Abbreviation = "HOD", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 6 },
                new Rank { Id = 79, Name = "la'", Abbreviation = "LA", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 7 },
                new Rank { Id = 80, Name = "Sogh", Abbreviation = "SOG", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 8 },
                new Rank { Id = 81, Name = "DevwI'", Abbreviation = "DEV", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 9 },
                new Rank { Id = 82, Name = "Da'", Abbreviation = "DA", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 10 },
                new Rank { Id = 83, Name = "beq", Abbreviation = "BE", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 11 },
                new Rank { Id = 84, Name = "rewbe'", Abbreviation = "RE", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 12 }
            );
        }
    }
}