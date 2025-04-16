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
        public DbSet<CharacterType> CharacterTypes { get; set; }
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

            // Add unique index to RoleName in PositionType
            builder.Entity<PositionType>()
                .HasIndex(pt => pt.RoleName)
                .IsUnique();

            // Add unique index to Name in PositionType
            builder.Entity<PositionType>()
                .HasIndex(pt => pt.Name)
                .IsUnique();

            // Add unique index to DisplayOrder in PositionType
            builder.Entity<PositionType>()
                .HasIndex(pt => pt.DisplayOrder)
                .IsUnique();

            // Soft delete filter for PositionType
            builder.Entity<PositionType>()
                .HasQueryFilter(pt => pt.IsActive);

            // Seeding Position Types
            builder.Entity<PositionType>().HasData(
                new PositionType { Id = 1, Name = "Universe Leader", RoleName = "UniverseLeader", Level = 1, RequiresScope = true, IsActive = true, DisplayOrder = 4 },
                new PositionType { Id = 2, Name = "Faction Leader", RoleName = "FactionLeader", Level = 2, RequiresScope = true, IsActive = true, DisplayOrder = 5 },
                new PositionType { Id = 3, Name = "Branch Leader", RoleName = "BranchLeader", Level = 3, RequiresScope = true, IsActive = true, DisplayOrder = 6 },
                new PositionType { Id = 4, Name = "Unit Leader", RoleName = "UnitLeader", Level = 5, RequiresScope = true, IsActive = true, DisplayOrder = 8 },
                new PositionType { Id = 5, Name = "SubUnit Leader", RoleName = "SubUnitLeader", Level = 6, RequiresScope = true, IsActive = true, DisplayOrder = 9 },
                new PositionType { Id = 6, Name = "Command Staff", RoleName = "CommandStaff", Level = 0, RequiresScope = false, IsActive = true, DisplayOrder = 1 },
                new PositionType { Id = 7, Name = "Command Staff Deputy", RoleName = "CommandStaffDeputy", Level = 1, RequiresScope = false, IsActive = true, DisplayOrder = 2 },
                new PositionType { Id = 8, Name = "Command Staff Assistant", RoleName = "CommandStaffAssistant", Level = 2, RequiresScope = false, IsActive = true, DisplayOrder = 3 },
                new PositionType { Id = 9, Name = "Branch Command", RoleName = "BranchCommand", Level = 4, RequiresScope = true, IsActive = true, DisplayOrder = 7 },
                new PositionType { Id = 10, Name = "Member", RoleName = "Member", Level = 7, RequiresScope = true, IsActive = true, DisplayOrder = 10 }
            );

            // Species Check Constraint
            builder.Entity<Species>().ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Species_ScopeOrGlobal",
                    "(UniverseId IS NOT NULL AND FactionId IS NOT NULL) OR " +
                    "(UniverseId IS NULL AND FactionId IS NULL)");
            });

            // Add unique index to Name in Species
            builder.Entity<Species>()
                .HasIndex(s => new { s.Name, s.UniverseId, s.FactionId })
                .IsUnique();

            // Add index to DisplayOrder in Species
            builder.Entity<Species>()
                .HasIndex(u => u.DisplayOrder);

            // Soft delete filter for Species
            builder.Entity<Species>()
                .HasQueryFilter(u => u.IsActive);

            // Add unique index to FactionId and DisplayOrder in Faction for composite awareness in case names repeat across universes
            builder.Entity<Species>()
                .HasIndex(s => new { s.FactionId, s.DisplayOrder })
                .IsUnique();

            // Seeding Species
            builder.Entity<Species>().HasData(
                new Species { Id = 1, Name = "Human", Description = "A baseline humanoid species found throughout the galaxy.", UniverseId = null, FactionId = null, IsActive = true, DisplayOrder = 1 },
                new Species { Id = 2, Name = "Human", UniverseId = 1, FactionId = 1, CanonicalSpeciesId = 1, IsActive = true, DisplayOrder = 1 },
                new Species { Id = 3, Name = "Human", UniverseId = 1, FactionId = 2, CanonicalSpeciesId = 1, IsActive = true, DisplayOrder = 1 },
                new Species { Id = 4, Name = "Human", UniverseId = 2, FactionId = 3, CanonicalSpeciesId = 1, IsActive = true, DisplayOrder = 1 },
                new Species { Id = 5, Name = "Wookiee", Description = "A tall, hairy species from Kashyyyk.", UniverseId = 1, FactionId = 2, IsActive = true, DisplayOrder = 2 },
                new Species { Id = 6, Name = "Vulcan", Description = "A logical species from the planet Vulcan.", UniverseId = 2, FactionId = 3, IsActive = true, DisplayOrder = 2 },
                new Species { Id = 7, Name = "Klingon", Description = "A warrior species from the planet Qo'noS.", UniverseId = 2, FactionId = 4, IsActive = true, DisplayOrder = 1 }
            );

            // Add unique index to Name in Gender
            builder.Entity<Gender>()
                .HasIndex(g => g.Name)
                .IsUnique();

            // Add index to DisplayOrder in Gender
            builder.Entity<Gender>()
                .HasIndex(g => g.DisplayOrder);

            // Soft delete filter for Gender
            builder.Entity<Gender>()
                .HasQueryFilter(g => g.IsActive);

            // Seeding Genders
            builder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Male", Description = "Identifies as male", IsActive = true, DisplayOrder = 1 },
                new Gender { Id = 2, Name = "Female", Description = "Identifies as female", IsActive = true, DisplayOrder = 2 },
                new Gender { Id = 3, Name = "Other", Description = "Non-binary, agender, or another identity", IsActive = true, DisplayOrder = 3 },
                new Gender { Id = 4, Name = "Prefer not to say", Description = "Chooses not to disclose gender", IsActive = true, DisplayOrder = 4 }
            );

            // Add unique index to Name in Universe
            builder.Entity<Universe>()
                .HasIndex(u => u.Name)
                .IsUnique();

            // Add index to DisplayOrder in Universe
            builder.Entity<Universe>()
                .HasIndex(u => u.DisplayOrder);

            // Soft delete filter for Universes
            builder.Entity<Universe>()
                .HasQueryFilter(u => u.IsActive);

            // Seeding Universes
            builder.Entity<Universe>().HasData(
                new Universe {
                    Id = 1,
                    Name = "Star Wars",
                    Description = "A galaxy far, far away",
                    DisplayOrder = 1,
                    IsActive = true,
                    UsesOffset = false,
                    OffsetYears = null,
                    UsesBBYABY = true,
                    BBYABYAnchorDate = new DateTime(1977, 5, 25),
                    DisplayFormat = "dd MMMM yyyy",
                    EnableStardate = false,
                    StardateBaseDate = null,
                    StardateMultiplier = null
                },
                new Universe
                {
                    Id = 2,
                    Name = "Star Trek",
                    Description = "The final frontier",
                    DisplayOrder = 2,
                    IsActive = true,
                    UsesOffset = true,
                    OffsetYears = 385,
                    UsesBBYABY = false,
                    BBYABYAnchorDate = null,
                    DisplayFormat = "ddd dd MMMM yyyy",
                    EnableStardate = true,
                    StardateBaseDate = new DateTime(2323, 1, 1),
                    StardateMultiplier = 1000.0 / 365.25 // ~2.7379
                }
            );

            // Add unique index to Name in Faction
            builder.Entity<Faction>()
                .HasIndex(u => u.Name)
                .IsUnique();

            // Add index to DisplayOrder in Faction
            builder.Entity<Faction>()
                .HasIndex(u => u.DisplayOrder);

            // Soft delete filter for Faction
            builder.Entity<Faction>()
                .HasQueryFilter(u => u.IsActive);

            // Add unique index to UniverseId and DisplayOrder in Faction for composite awareness in case names repeat across universes
            builder.Entity<Faction>()
                .HasIndex(f => new { f.UniverseId, f.DisplayOrder })
                .IsUnique();

            // Faction Check Constraint
            builder.Entity<Faction>().ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Faction_UniverseRequired", "UniverseId IS NOT NULL");
            });

            // Seeding Factions
            builder.Entity<Faction>().HasData(
                new Faction { Id = 1, Name = "Galactic Empire", UniverseId = 1, DisplayOrder = 1, IsActive = true },
                new Faction { Id = 2, Name = "Rebellion", UniverseId = 1, DisplayOrder = 2, IsActive = true },
                new Faction { Id = 3, Name = "United Federation of Planets", UniverseId = 2, DisplayOrder = 1, IsActive = true },
                new Faction { Id = 4, Name = "tlhIngan wo'", UniverseId = 2, DisplayOrder = 2, IsActive = true }
            );

            // Add index to DisplayOrder in Branch
            builder.Entity<Branch>()
                .HasIndex(u => u.DisplayOrder);

            // Soft delete filter for Branch
            builder.Entity<Branch>()
                .HasQueryFilter(u => u.IsActive);

            // Add unique index to FactionId and DisplayOrder in Branch for composite awareness in case names repeat across universes
            builder.Entity<Branch>()
                .HasIndex(f => new { f.FactionId, f.DisplayOrder })
                .IsUnique();

            // Branch Check Constraint
            builder.Entity<Branch>().ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Branch_UniverseAndFactionRequired", "UniverseId IS NOT NULL AND FactionId IS NOT NULL");
            });

            // Seeding Branches
            builder.Entity<Branch>().HasData(
                new Branch { Id = 1, Name = "Imperial Navy", UniverseId = 1, FactionId = 1, DisplayOrder = 1, IsActive = true },
                new Branch { Id = 3, Name = "Stormtrooper Legion", UniverseId = 1, FactionId = 1, DisplayOrder = 2, IsActive = true },
                new Branch { Id = 2, Name = "Rebel Fleet", UniverseId = 1, FactionId = 2, DisplayOrder = 1, IsActive = true },
                new Branch { Id = 4, Name = "Rebel Troopers", UniverseId = 1, FactionId = 2, DisplayOrder = 2, IsActive = true },
                new Branch { Id = 5, Name = "Starfleet", UniverseId = 2, FactionId = 3, DisplayOrder = 1, IsActive = true },
                new Branch { Id = 6, Name = "tlhIngan Hubbeq", UniverseId = 2, FactionId = 4, DisplayOrder = 1, IsActive = true }
            );

            // Unit Check Constraint
            builder.Entity<Unit>().ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Unit_UniverseAndFactionAndBranchRequired", "UniverseId IS NOT NULL AND FactionId IS NOT NULL AND BranchId IS NOT NULL");
            });

            // Add index to DisplayOrder in Unit
            builder.Entity<Unit>()
                .HasIndex(u => u.DisplayOrder);

            // Soft delete filter for Unit
            builder.Entity<Unit>()
                .HasQueryFilter(u => u.IsActive);

            // Add unique index to BranchId and DisplayOrder in Unit for composite awareness in case names repeat across universes
            builder.Entity<Unit>()
                .HasIndex(f => new { f.BranchId, f.DisplayOrder })
                .IsUnique();

            // Seeding Units
            builder.Entity<Unit>().HasData(
                new Unit { Id = 1, Name = "1st Sector Fleet", UniverseId = 1, FactionId = 1, BranchId = 1, DisplayOrder = 1, IsActive = true },
                new Unit { Id = 2, Name = "ISD Devastator", UniverseId = 1, FactionId = 1, BranchId = 1, ParentUnitId = 1, DisplayOrder = 2, IsActive = true },
                new Unit { Id = 3, Name = "10th Attack Wing", UniverseId = 1, FactionId = 2, BranchId = 1, ParentUnitId = 2, DisplayOrder = 3, IsActive = true },
                new Unit { Id = 4, Name = "14th Bombardment Wing", UniverseId = 1, FactionId = 2, BranchId = 1, ParentUnitId = 3, DisplayOrder = 4, IsActive = true },
                new Unit { Id = 5, Name = "116th Fighter Squadron", UniverseId = 1, FactionId = 2, BranchId = 1, ParentUnitId = 4, DisplayOrder = 5, IsActive = true },
                new Unit { Id = 6, Name = "12th Bomber Squadron", UniverseId = 1, FactionId = 2, BranchId = 1, ParentUnitId = 4, DisplayOrder = 6, IsActive = true },
                new Unit { Id = 7, Name = "Fifth Fleet", UniverseId = 2, FactionId = 3, BranchId = 5, DisplayOrder = 1, IsActive = true },
                new Unit { Id = 8, Name = "3rd Cruiser Wing", UniverseId = 2, FactionId = 3, BranchId = 5, ParentUnitId = 7, DisplayOrder = 2, IsActive = true },
                new Unit { Id = 9, Name = "USS Avalon", UniverseId = 2, FactionId = 3, BranchId = 5, ParentUnitId = 8, DisplayOrder = 3, IsActive = true },
                new Unit { Id = 10, Name = "USS Venture", UniverseId = 2, FactionId = 3, BranchId = 5, ParentUnitId = 8, DisplayOrder = 4, IsActive = true },
                new Unit { Id = 11, Name = "15th Stormtrooper Legion", UniverseId = 1, FactionId = 1, BranchId = 3, DisplayOrder = 1, IsActive = true },
                new Unit { Id = 12, Name = "1st Cohort", UniverseId = 1, FactionId = 1, BranchId = 3, ParentUnitId = 11, DisplayOrder = 2, IsActive = true },
                new Unit { Id = 13, Name = "Aurek Century", UniverseId = 1, FactionId = 1, BranchId = 3, ParentUnitId = 12, DisplayOrder = 3, IsActive = true },
                new Unit { Id = 14, Name = "Alpha Phalanx", UniverseId = 1, FactionId = 1, BranchId = 3, ParentUnitId = 13, DisplayOrder = 4, IsActive = true },
                new Unit { Id = 15, Name = "6th Rebel Fleet", UniverseId = 1, FactionId = 2, BranchId = 2, DisplayOrder = 1, IsActive = true },
                new Unit { Id = 16, Name = "Vanguard Task Group", UniverseId = 1, FactionId = 2, BranchId = 2, ParentUnitId = 15, DisplayOrder = 2, IsActive = true },
                new Unit { Id = 17, Name = "Red Wing", UniverseId = 1, FactionId = 2, BranchId = 2, ParentUnitId = 16, DisplayOrder = 3, IsActive = true },
                new Unit { Id = 18, Name = "Rogue Squadron", UniverseId = 1, FactionId = 2, BranchId = 2, ParentUnitId = 16, DisplayOrder = 4, IsActive = true },
                new Unit { Id = 19, Name = "Strike Fleet Qapla'", UniverseId = 2, FactionId = 4, BranchId = 6, DisplayOrder = 1, IsActive = true },
                new Unit { Id = 20, Name = "Raiding Group Mogh", UniverseId = 2, FactionId = 4, BranchId = 6, ParentUnitId = 19, DisplayOrder = 2, IsActive = true },
                new Unit { Id = 21, Name = "Strike Wing SuvwI'", UniverseId = 2, FactionId = 4, BranchId = 6, ParentUnitId = 20, DisplayOrder = 3, IsActive = true },
                new Unit { Id = 22, Name = "Blade Flight K'Tok", UniverseId = 2, FactionId = 4, BranchId = 6, ParentUnitId = 21, DisplayOrder = 4, IsActive = true }
            );

            // Position Check Constraint
            builder.Entity<Position>().Property<bool>("RequiresScope");
            builder.Entity<Position>().ToTable(tb =>
                {
                    tb.HasCheckConstraint("CK_Position_RequiresScopeFields",
                        "(RequiresScope = 0) OR (UniverseId IS NOT NULL)");
                });

            // Add unique index to PositionTypeId in Position
            builder.Entity<Position>()
                .HasIndex(p => p.PositionTypeId);

            // Soft delete filter for Position
            builder.Entity<Position>()
                .HasQueryFilter(p => p.IsActive);

            // Seeding Positions
            builder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Vanguard Commander", PositionTypeId = 6, Abbreviation = "VCO", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 1, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 2, Name = "Vanguard Executive Officer", PositionTypeId = 6, Abbreviation = "VXO", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 2, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 3, Name = "Vanguard Director of Operations", PositionTypeId = 6, Abbreviation = "VDO", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 3, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 4, Name = "Vanguard Director of Engineering", PositionTypeId = 6, Abbreviation = "VDE", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 4, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 5, Name = "Vanguard Director of Training", PositionTypeId = 6, Abbreviation = "VDT", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 5, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 6, Name = "Vanguard Director of Intelligence", PositionTypeId = 6, Abbreviation = "VDI", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 6, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 7, Name = "Vanguard Director of Communications", PositionTypeId = 6, Abbreviation = "VDC", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 7, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 8, Name = "Vanguard Director of Science", PositionTypeId = 6, Abbreviation = "VDS", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 8, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 9, Name = "Vanguard Judge Advocate", PositionTypeId = 6, Abbreviation = "VJA", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 9, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 10, Name = "Star Wars Universe Leader", PositionTypeId = 1, Abbreviation = "SWUL", UniverseId = 1, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 11, Name = "Imperial Emperor", PositionTypeId = 2, Abbreviation = "EMP", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 1, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 12, Name = "Commander-in-chief, Imperial Navy", PositionTypeId = 3, Abbreviation = "CCIN", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 1, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 13, Name = "Imperial Personnel Officer", PositionTypeId = 9, Abbreviation = "IPO", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 2, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 14, Name = "Imperial Academy Commandant", PositionTypeId = 9, Abbreviation = "IAC", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 3, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 15, Name = "Fleet Commander", PositionTypeId = 4, Abbreviation = "FC", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 4, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 16, Name = "Taskforce Commander", PositionTypeId = 4, Abbreviation = "TFC", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 5, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 17, Name = "Ship Command Officer", PositionTypeId = 4, Abbreviation = "SCO", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 6, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 18, Name = "Wing Commander", PositionTypeId = 4, Abbreviation = "WC", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 7, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 19, Name = "Squadron Commander", PositionTypeId = 4, Abbreviation = "SQC", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 8, MinRankLevel = 10, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 20, Name = "Squadron Flight Leader", PositionTypeId = 4, Abbreviation = "SFL", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 9, MinRankLevel = 12, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 21, Name = "Squadron Member", PositionTypeId = 10, Abbreviation = "SM", UniverseId = 1, FactionId = 1, BranchId = 1, UnitId = null, DisplayOrder = 10, MinRankLevel = 14, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 22, Name = "Legion Commander", PositionTypeId = 3, Abbreviation = "LEC", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, DisplayOrder = 1, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 23, Name = "Stormtrooper Command 1", PositionTypeId = 9, Abbreviation = "SC1", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, DisplayOrder = 2, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 24, Name = "Stormtrooper Command 2", PositionTypeId = 9, Abbreviation = "SC2", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, DisplayOrder = 3, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 25, Name = "Sector Commander", PositionTypeId = 4, Abbreviation = "SEC", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, DisplayOrder = 4, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 26, Name = "Battalion Commander", PositionTypeId = 4, Abbreviation = "BC", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, DisplayOrder = 5, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 27, Name = "Company Commander", PositionTypeId = 4, Abbreviation = "CC", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, DisplayOrder = 6, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 28, Name = "Assault Team Leader", PositionTypeId = 4, Abbreviation = "ATL", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, DisplayOrder = 7, MinRankLevel = 11, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 29, Name = "Assault Team Executive Officer", PositionTypeId = 4, Abbreviation = "ATX", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, DisplayOrder = 8, MinRankLevel = 12, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 30, Name = "Trooper", PositionTypeId = 10, Abbreviation = "MAR", UniverseId = 1, FactionId = 1, BranchId = 3, UnitId = null, DisplayOrder = 9, MinRankLevel = 15, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 31, Name = "Chancellor of the Alliance", PositionTypeId = 2, Abbreviation = "COTA", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, DisplayOrder = 1, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 32, Name = "Admiral of the Fleet", PositionTypeId = 3, Abbreviation = "AF", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, DisplayOrder = 1, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 33, Name = "Rebel Fleet Command 1", PositionTypeId = 9, Abbreviation = "RFC1", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, DisplayOrder = 2, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 34, Name = "Rebel Fleet Command 2", PositionTypeId = 9, Abbreviation = "RFC2", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, DisplayOrder = 3, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 35, Name = "Fleet Commander", PositionTypeId = 4, Abbreviation = "FC", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, DisplayOrder = 4, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 36, Name = "Taskforce Commander", PositionTypeId = 4, Abbreviation = "TFC", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, DisplayOrder = 5, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 37, Name = "Commanding Officer", PositionTypeId = 4, Abbreviation = "CO", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, DisplayOrder = 6, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 38, Name = "Executive Officer", PositionTypeId = 4, Abbreviation = "XO", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, DisplayOrder = 7, MinRankLevel = 6, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 39, Name = "Department Head", PositionTypeId = 4, Abbreviation = "DH", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, DisplayOrder = 8, MinRankLevel = 8, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 40, Name = "Officer", PositionTypeId = 10, Abbreviation = "OF", UniverseId = 1, FactionId = 2, BranchId = 2, UnitId = null, DisplayOrder = 9, MinRankLevel = 10, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 41, Name = "Commanding General", PositionTypeId = 3, Abbreviation = "CGEN", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, DisplayOrder = 1, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 42, Name = "Rebel Trooper Command 1", PositionTypeId = 9, Abbreviation = "RTC1", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, DisplayOrder = 2, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 43, Name = "Rebel Trooper Command 2", PositionTypeId = 9, Abbreviation = "RTC2", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, DisplayOrder = 3, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 44, Name = "Sector Division Commander", PositionTypeId = 4, Abbreviation = "SDC", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, DisplayOrder = 4, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 45, Name = "Fleet Division Commander", PositionTypeId = 4, Abbreviation = "FDC", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, DisplayOrder = 5, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 46, Name = "Brigade Leader", PositionTypeId = 4, Abbreviation = "BL", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, DisplayOrder = 6, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 47, Name = "Company Leader", PositionTypeId = 4, Abbreviation = "CL", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, DisplayOrder = 7, MinRankLevel = 8, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 48, Name = "Troop Leader", PositionTypeId = 4, Abbreviation = "TL", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, DisplayOrder = 8, MinRankLevel = 11, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 49, Name = "Troop Deputy", PositionTypeId = 4, Abbreviation = "TD", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, DisplayOrder = 9, MinRankLevel = 12, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 50, Name = "Solider", PositionTypeId = 10, Abbreviation = "SOL", UniverseId = 1, FactionId = 2, BranchId = 4, UnitId = null, DisplayOrder = 10, MinRankLevel = 15, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 51, Name = "Star Trek Universe Leader", PositionTypeId = 1, Abbreviation = "STUL", UniverseId = 2, FactionId = null, BranchId = null, DisplayOrder = 1, UnitId = null, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 52, Name = "President of the United Federation of Planets", PositionTypeId = 2, Abbreviation = "PRES", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 1, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 53, Name = "Chief of Starfleet Operations", PositionTypeId = 3, Abbreviation = "CSO", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 1, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 54, Name = "Chief of Starfleet Personnel and Training", PositionTypeId = 9, Abbreviation = "CSP", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 2, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 55, Name = "Chief of Starfleet Science and Exploration", PositionTypeId = 9, Abbreviation = "CSSE", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 3, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 56, Name = "Sector Commander", PositionTypeId = 4, Abbreviation = "SC", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 4, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 57, Name = "Fleet Commander", PositionTypeId = 4, Abbreviation = "FC", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 5, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 58, Name = "Taskforce Commander", PositionTypeId = 4, Abbreviation = "TFC", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 6, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 59, Name = "Commanding Officer", PositionTypeId = 4, Abbreviation = "CO", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 7, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 60, Name = "Executive Officer", PositionTypeId = 4, Abbreviation = "XO", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 8, MinRankLevel = 8, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 61, Name = "Department Head", PositionTypeId = 4, Abbreviation = "DH", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 9, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 62, Name = "Officer", PositionTypeId = 10, Abbreviation = "OF", UniverseId = 2, FactionId = 3, BranchId = 5, UnitId = null, DisplayOrder = 10, MinRankLevel = 12, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 63, Name = "paQ'dIj", PositionTypeId = 2, Abbreviation = "PAQ", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, DisplayOrder = 1, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 64, Name = "Supreme Commander, tlhIngan Hubbeq", PositionTypeId = 3, Abbreviation = "SCTH", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, DisplayOrder = 1, MinRankLevel = 2, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 65, Name = "Personnel Officer, tlhIngan Hubbeq", PositionTypeId = 9, Abbreviation = "POTH", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, DisplayOrder = 2, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 66, Name = "Battle Officer, tlhIngan Hubbeq", PositionTypeId = 9, Abbreviation = "BOTH", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, DisplayOrder = 3, MinRankLevel = 3, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 67, Name = "Fleet Commander", PositionTypeId = 4, Abbreviation = "FC", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, DisplayOrder = 4, MinRankLevel = 4, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 68, Name = "Taskgroup Commander", PositionTypeId = 4, Abbreviation = "TGC", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, DisplayOrder = 5, MinRankLevel = 5, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 69, Name = "Commanding Officer", PositionTypeId = 4, Abbreviation = "CO", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, DisplayOrder = 6, MinRankLevel = 7, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 70, Name = "Executive Officer", PositionTypeId = 4, Abbreviation = "XO", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, DisplayOrder = 7, MinRankLevel = 8, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 71, Name = "Department Head", PositionTypeId = 4, Abbreviation = "DH", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, DisplayOrder = 8, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 72, Name = "Officer", PositionTypeId = 10, Abbreviation = "OF", UniverseId = 2, FactionId = 4, BranchId = 6, UnitId = null, DisplayOrder = 1, MinRankLevel = 12, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = true },
                new Position { Id = 73, Name = "Deputy Director of Engineering", PositionTypeId = 7, Abbreviation = "DDE", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 74, Name = "Deputy Director of Operations - Personnel", PositionTypeId = 7, Abbreviation = "DDO-P", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 75, Name = "Deputy Director of Operations - Tactics", PositionTypeId = 7, Abbreviation = "DDO-T", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 2, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 76, Name = "Deputy Director of Training", PositionTypeId = 7, Abbreviation = "DDT", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 77, Name = "Deputy Director of Intelligence", PositionTypeId = 7, Abbreviation = "DDI", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 78, Name = "Deputy Director of Communications", PositionTypeId = 7, Abbreviation = "DDC", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 79, Name = "Deputy Director of Science", PositionTypeId = 7, Abbreviation = "DDS", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 80, Name = "Engineering Department Command Assistant", PositionTypeId = 8, Abbreviation = "EDCA", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 81, Name = "Operations Department Command Assistant", PositionTypeId = 8, Abbreviation = "ODCA", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 82, Name = "Training Department Command Assistant", PositionTypeId = 8, Abbreviation = "TDCA", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 83, Name = "Intelligence Department Command Assistant", PositionTypeId = 8, Abbreviation = "IDCA", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 84, Name = "Communications Department Command Assistant", PositionTypeId = 8, Abbreviation = "CDCA", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 85, Name = "Science Department Command Assistant", PositionTypeId = 8, Abbreviation = "SDCA", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false },
                new Position { Id = 86, Name = "Investigator", PositionTypeId = 8, Abbreviation = "INV", UniverseId = null, FactionId = null, BranchId = null, UnitId = null, DisplayOrder = 1, MinRankLevel = 9, MaxRankLevel = 1, ImageUrl = null, IsActive = true, RequiresScope = false }
            );

            // Rank Check Constraint
            builder.Entity<Rank>().ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Rank_ScopeOrGlobal",
                    "(UniverseId IS NOT NULL AND FactionId IS NOT NULL AND BranchId IS NOT NULL) OR " +
                    "(UniverseId IS NULL AND FactionId IS NULL AND BranchId IS NULL)");
            });

            // Add index to DisplayOrder in Rank
            builder.Entity<Rank>()
                .HasIndex(u => u.DisplayOrder);

            // Soft delete filter for Rank
            builder.Entity<Rank>()
                .HasQueryFilter(u => u.IsActive);

            // Add unique index to BranchId and DisplayOrder in Rank for composite awareness in case names repeat across branches
            builder.Entity<Rank>()
                .HasIndex(f => new { f.BranchId, f.DisplayOrder })
                .IsUnique();

            // Seeding Ranks
            builder.Entity<Rank>().HasData(
                new Rank { Id = 1, Name = "Grand Admiral", Abbreviation = "GA", UniverseId = null, FactionId = null, BranchId = null, Level = 1, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 2, Name = "Lord High Admiral", Abbreviation = "LHA", UniverseId = null, FactionId = null, BranchId = null, Level = 2, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 3, Name = "High Admiral", Abbreviation = "HADM", UniverseId = null, FactionId = null, BranchId = null, Level = 3, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 4, Name = "Fleet Admiral", Abbreviation = "FADM", UniverseId = null, FactionId = null, BranchId = null, Level = 4, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 5, Name = "Admiral", Abbreviation = "ADM", UniverseId = null, FactionId = null, BranchId = null, Level = 5, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 6, Name = "Vice Admiral", Abbreviation = "VADM", UniverseId = null, FactionId = null, BranchId = null, Level = 6, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 7, Name = "Rear Admiral", Abbreviation = "RADM", UniverseId = null, FactionId = null, BranchId = null, Level = 7, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 8, Name = "Commodore", Abbreviation = "COMM", UniverseId = null, FactionId = null, BranchId = null, Level = 8, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 9, Name = "Captain", Abbreviation = "CPT", UniverseId = null, FactionId = null, BranchId = null, Level = 9, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 10, Name = "Fleet Admiral", Abbreviation = "FADM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 1, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 11, Name = "Admiral", Abbreviation = "ADM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 2, IsActive = true, DisplayOrder = 2 },
                new Rank { Id = 12, Name = "Vice Admiral", Abbreviation = "VADM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 3, IsActive = true, DisplayOrder = 3 },
                new Rank { Id = 13, Name = "Rear Admiral", Abbreviation = "RADM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 4, IsActive = true, DisplayOrder = 4 },
                new Rank { Id = 14, Name = "Commodore", Abbreviation = "COM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 5, IsActive = true, DisplayOrder = 5 },
                new Rank { Id = 15, Name = "Colonel", Abbreviation = "COL", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 6, IsActive = true, DisplayOrder = 6 },
                new Rank { Id = 16, Name = "Lieutenant Colonel", Abbreviation = "LTCOL", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 7, IsActive = true, DisplayOrder = 7 },
                new Rank { Id = 17, Name = "Major", Abbreviation = "MAJ", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 8, IsActive = true, DisplayOrder = 8 },
                new Rank { Id = 18, Name = "Captain", Abbreviation = "CPT", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 9, IsActive = true, DisplayOrder = 9 },
                new Rank { Id = 19, Name = "Commander", Abbreviation = "COM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 10, IsActive = true, DisplayOrder = 10 },
                new Rank { Id = 20, Name = "Lieutenant Commander", Abbreviation = "LTCOM", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 11, IsActive = true, DisplayOrder = 11 },
                new Rank { Id = 21, Name = "Lieutenant", Abbreviation = "LT", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 12, IsActive = true, DisplayOrder = 12 },
                new Rank { Id = 22, Name = "Sub-Lieutenant", Abbreviation = "SLT", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 13, IsActive = true, DisplayOrder = 13 },
                new Rank { Id = 23, Name = "Ensign", Abbreviation = "ENS", UniverseId = 1, FactionId = 1, BranchId = 1, Level = 14, IsActive = true, DisplayOrder = 14 },
                new Rank { Id = 24, Name = "Legion General", Abbreviation = "LEGEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 1, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 25, Name = "High General", Abbreviation = "HGEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 2, IsActive = true, DisplayOrder = 2 },
                new Rank { Id = 26, Name = "General", Abbreviation = "GEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 3, IsActive = true, DisplayOrder = 3 },
                new Rank { Id = 27, Name = "Lieutenant General", Abbreviation = "LGEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 4, IsActive = true, DisplayOrder = 4 },
                new Rank { Id = 28, Name = "Major General", Abbreviation = "MGEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 5, IsActive = true, DisplayOrder = 5 },
                new Rank { Id = 29, Name = "Brigadier General", Abbreviation = "BGEN", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 6, IsActive = true, DisplayOrder = 6 },
                new Rank { Id = 30, Name = "Colonel", Abbreviation = "COL", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 7, IsActive = true, DisplayOrder = 7 },
                new Rank { Id = 31, Name = "Lieutenant Colonel", Abbreviation = "LTCOL", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 8, IsActive = true, DisplayOrder = 8 },
                new Rank { Id = 32, Name = "Major", Abbreviation = "MAJ", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 9, IsActive = true, DisplayOrder = 9 },
                new Rank { Id = 33, Name = "Captain", Abbreviation = "CPT", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 10, IsActive = true, DisplayOrder = 10 },
                new Rank { Id = 34, Name = "First Lieutenant", Abbreviation = "1LT", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 11, IsActive = true, DisplayOrder = 11 },
                new Rank { Id = 35, Name = "Second Lieutenant", Abbreviation = "2LT", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 12, IsActive = true, DisplayOrder = 12 },
                new Rank { Id = 36, Name = "Sergeant", Abbreviation = "SGT", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 13, IsActive = true, DisplayOrder = 13 },
                new Rank { Id = 37, Name = "Corporal", Abbreviation = "CPL", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 14, IsActive = true, DisplayOrder = 14 },
                new Rank { Id = 38, Name = "Private", Abbreviation = "PVT", UniverseId = 1, FactionId = 1, BranchId = 3, Level = 15, IsActive = true, DisplayOrder = 15 },
                new Rank { Id = 39, Name = "Admiral", Abbreviation = "ADM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 1, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 40, Name = "Vice Admiral", Abbreviation = "VADM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 2, IsActive = true, DisplayOrder = 2 },
                new Rank { Id = 41, Name = "Rear Admiral", Abbreviation = "RADM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 3, IsActive = true, DisplayOrder = 3 },
                new Rank { Id = 42, Name = "Commodore", Abbreviation = "COM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 4, IsActive = true, DisplayOrder = 4 },
                new Rank { Id = 43, Name = "Captain", Abbreviation = "CPT", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 5, IsActive = true, DisplayOrder = 5 },
                new Rank { Id = 44, Name = "Commander", Abbreviation = "COM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 6, IsActive = true, DisplayOrder = 6 },
                new Rank { Id = 45, Name = "Lieutenant Commander", Abbreviation = "LTCOM", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 7, IsActive = true, DisplayOrder = 7 },
                new Rank { Id = 46, Name = "Lieutenant", Abbreviation = "LT", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 8, IsActive = true, DisplayOrder = 8 },
                new Rank { Id = 47, Name = "Lieutenant Junior Grade", Abbreviation = "LTJG", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 9, IsActive = true, DisplayOrder = 9 },
                new Rank { Id = 48, Name = "Ensign", Abbreviation = "ENS", UniverseId = 1, FactionId = 2, BranchId = 2, Level = 10, IsActive = true, DisplayOrder = 10 },
                new Rank { Id = 49, Name = "Trooper General", Abbreviation = "TGEN", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 1, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 50, Name = "General", Abbreviation = "GEN", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 2, IsActive = true, DisplayOrder = 2 },
                new Rank { Id = 51, Name = "Lieutenant General", Abbreviation = "LGEN", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 3, IsActive = true, DisplayOrder = 3 },
                new Rank { Id = 52, Name = "Major General", Abbreviation = "MGEN", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 4, IsActive = true, DisplayOrder = 4 },
                new Rank { Id = 53, Name = "Brigadier General", Abbreviation = "BGEN", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 5, IsActive = true, DisplayOrder = 5 },
                new Rank { Id = 54, Name = "Colonel", Abbreviation = "COL", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 6, IsActive = true, DisplayOrder = 6 },
                new Rank { Id = 55, Name = "Lieutenant Colonel", Abbreviation = "LTCOL", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 7, IsActive = true, DisplayOrder = 7 },
                new Rank { Id = 56, Name = "Major", Abbreviation = "MAJ", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 8, IsActive = true, DisplayOrder = 8 },
                new Rank { Id = 57, Name = "Captain", Abbreviation = "CPT", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 9, IsActive = true, DisplayOrder = 9 },
                new Rank { Id = 58, Name = "Lieutenant", Abbreviation = "LT", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 10, IsActive = true, DisplayOrder = 10 },
                new Rank { Id = 59, Name = "Officer Cadet", Abbreviation = "OC", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 11, IsActive = true, DisplayOrder = 11 },
                new Rank { Id = 60, Name = "Sergeant", Abbreviation = "SGT", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 12, IsActive = true, DisplayOrder = 12 },
                new Rank { Id = 61, Name = "Corporal", Abbreviation = "CPL", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 13, IsActive = true, DisplayOrder = 13 },
                new Rank { Id = 62, Name = "Private", Abbreviation = "PVT", UniverseId = 1, FactionId = 2, BranchId = 4, Level = 14, IsActive = true, DisplayOrder = 14 },
                new Rank { Id = 63, Name = "Fleet Admiral", Abbreviation = "FADM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 1, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 64, Name = "Admiral", Abbreviation = "ADM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 2, IsActive = true, DisplayOrder = 2 },
                new Rank { Id = 65, Name = "Vice Admiral", Abbreviation = "VADM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 3, IsActive = true, DisplayOrder = 3 },
                new Rank { Id = 66, Name = "Rear Admiral", Abbreviation = "RADM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 4, IsActive = true, DisplayOrder = 4 },
                new Rank { Id = 67, Name = "Commodore", Abbreviation = "COM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 5, IsActive = true, DisplayOrder = 5 },
                new Rank { Id = 68, Name = "Captain", Abbreviation = "CPT", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 6, IsActive = true, DisplayOrder = 6 },
                new Rank { Id = 69, Name = "Commander", Abbreviation = "COM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 7, IsActive = true, DisplayOrder = 7 },
                new Rank { Id = 70, Name = "Lieutenant Commander", Abbreviation = "LTCOM", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 8, IsActive = true, DisplayOrder = 8 },
                new Rank { Id = 71, Name = "Lieutenant", Abbreviation = "LT", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 9, IsActive = true, DisplayOrder = 9 },
                new Rank { Id = 72, Name = "Lieutenant Junior Grade", Abbreviation = "LTJG", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 10, IsActive = true, DisplayOrder = 10 },
                new Rank { Id = 73, Name = "Ensign", Abbreviation = "ENS", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 11, IsActive = true, DisplayOrder = 11 },
                new Rank { Id = 74, Name = "Cadet", Abbreviation = "CDT", UniverseId = 2, FactionId = 3, BranchId = 5, Level = 12, IsActive = true, DisplayOrder = 12 },
                new Rank { Id = 75, Name = "'ajyo'", Abbreviation = "AJYO", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 1, IsActive = true, DisplayOrder = 1 },
                new Rank { Id = 76, Name = "'aj", Abbreviation = "AJ", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 2, IsActive = true, DisplayOrder = 2 },
                new Rank { Id = 77, Name = "totlh", Abbreviation = "TOT", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 3, IsActive = true, DisplayOrder = 3 },
                new Rank { Id = 78, Name = "HoDghom", Abbreviation = "HODG", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 4, IsActive = true, DisplayOrder = 4 },
                new Rank { Id = 79, Name = "HoDyo'", Abbreviation = "HODY", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 5, IsActive = true, DisplayOrder = 5 },
                new Rank { Id = 80, Name = "HoD", Abbreviation = "HOD", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 6, IsActive = true, DisplayOrder = 6 },
                new Rank { Id = 81, Name = "la'", Abbreviation = "LA", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 7, IsActive = true, DisplayOrder = 7 },
                new Rank { Id = 82, Name = "Sogh", Abbreviation = "SOG", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 8, IsActive = true, DisplayOrder = 8 },
                new Rank { Id = 83, Name = "DevwI'", Abbreviation = "DEV", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 9, IsActive = true, DisplayOrder = 9 },
                new Rank { Id = 84, Name = "Da'", Abbreviation = "DA", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 10, IsActive = true, DisplayOrder = 10 },
                new Rank { Id = 85, Name = "beq", Abbreviation = "BE", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 11, IsActive = true, DisplayOrder = 11 },
                new Rank { Id = 86, Name = "rewbe'", Abbreviation = "RE", UniverseId = 2, FactionId = 4, BranchId = 6, Level = 12, IsActive = true, DisplayOrder = 12 }
            );

            // Seeding CharacterType
            builder.Entity<CharacterType>().HasData(
                new CharacterType { Id = 1, Name = "Player" },
                new CharacterType { Id = 2, Name = "NPC" }
            );
        }
    }
}