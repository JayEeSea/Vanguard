using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vanguard.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeZone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PositionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    RequiresScope = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Universes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    UsesOffset = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OffsetYears = table.Column<int>(type: "int", nullable: true),
                    UsesBBYABY = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BBYABYAnchorDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DisplayFormat = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnableStardate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StardateBaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    StardateMultiplier = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniverseId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                    table.CheckConstraint("CK_Faction_UniverseRequired", "UniverseId IS NOT NULL");
                    table.ForeignKey(
                        name: "FK_Factions_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniverseId = table.Column<int>(type: "int", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.CheckConstraint("CK_Branch_UniverseAndFactionRequired", "UniverseId IS NOT NULL AND FactionId IS NOT NULL");
                    table.ForeignKey(
                        name: "FK_Branches_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Branches_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniverseId = table.Column<int>(type: "int", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CanonicalSpeciesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.CheckConstraint("CK_Species_ScopeOrGlobal", "(UniverseId IS NOT NULL AND FactionId IS NOT NULL) OR (UniverseId IS NULL AND FactionId IS NULL)");
                    table.ForeignKey(
                        name: "FK_Species_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Species_Species_CanonicalSpeciesId",
                        column: x => x.CanonicalSpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Species_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniverseId = table.Column<int>(type: "int", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                    table.CheckConstraint("CK_Rank_ScopeOrGlobal", "(UniverseId IS NOT NULL AND FactionId IS NOT NULL AND BranchId IS NOT NULL) OR (UniverseId IS NULL AND FactionId IS NULL AND BranchId IS NULL)");
                    table.ForeignKey(
                        name: "FK_Ranks_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ranks_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ranks_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    UniverseId = table.Column<int>(type: "int", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipClasses", x => x.Id);
                    table.CheckConstraint("CK_ShipClass_UniverseAndFactionAndBranchRequired", "UniverseId IS NOT NULL AND FactionId IS NOT NULL AND BranchId IS NOT NULL");
                    table.ForeignKey(
                        name: "FK_ShipClasses_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShipClasses_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShipClasses_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShipRegistry = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    UniverseId = table.Column<int>(type: "int", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    ShipClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ship", x => x.Id);
                    table.CheckConstraint("CK_Ship_UniverseAndFactionAndBranchRequired", "UniverseId IS NOT NULL AND FactionId IS NOT NULL AND BranchId IS NOT NULL");
                    table.ForeignKey(
                        name: "FK_Ship_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ship_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ship_ShipClasses_ShipClassId",
                        column: x => x.ShipClassId,
                        principalTable: "ShipClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ship_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniverseId = table.Column<int>(type: "int", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    ParentUnitId = table.Column<int>(type: "int", nullable: true),
                    ShipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.CheckConstraint("CK_Unit_UniverseAndFactionAndBranchRequired", "UniverseId IS NOT NULL AND FactionId IS NOT NULL AND BranchId IS NOT NULL");
                    table.ForeignKey(
                        name: "FK_Units_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_Ship_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ship",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_Units_ParentUnitId",
                        column: x => x.ParentUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Npc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CharacterTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    AddressedName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Appearance = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Personality = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Background = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpeciesId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    RankId = table.Column<int>(type: "int", nullable: true),
                    UniverseId = table.Column<int>(type: "int", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastPromotionDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LastMedalDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Npc_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Npc_CharacterTypes_CharacterTypeId",
                        column: x => x.CharacterTypeId,
                        principalTable: "CharacterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Npc_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Npc_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Npc_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Npc_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Npc_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Npc_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PositionTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MinRankLevel = table.Column<int>(type: "int", nullable: true),
                    MinRankId = table.Column<int>(type: "int", nullable: true),
                    MaxRankLevel = table.Column<int>(type: "int", nullable: true),
                    MaxRankId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniverseId = table.Column<int>(type: "int", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    RequiresScope = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.CheckConstraint("CK_Position_RequiresScopeFields", "(RequiresScope = 0) OR (UniverseId IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_Positions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Positions_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Positions_PositionTypes_PositionTypeId",
                        column: x => x.PositionTypeId,
                        principalTable: "PositionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Positions_Ranks_MaxRankId",
                        column: x => x.MaxRankId,
                        principalTable: "Ranks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Positions_Ranks_MinRankId",
                        column: x => x.MinRankId,
                        principalTable: "Ranks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Positions_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Positions_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CharacterTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    AddressedName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Appearance = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Personality = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Background = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpeciesId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    RankId = table.Column<int>(type: "int", nullable: true),
                    UniverseId = table.Column<int>(type: "int", nullable: true),
                    FactionId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastPromotionDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LastMedalDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_CharacterTypes_CharacterTypeId",
                        column: x => x.CharacterTypeId,
                        principalTable: "CharacterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CharacterTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Player" },
                    { 2, "NPC" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Description", "DisplayOrder", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "Identifies as male", 1, true, "Male" },
                    { 2, "Identifies as female", 2, true, "Female" },
                    { 3, "Non-binary, agender, or another identity", 3, true, "Other" },
                    { 4, "Chooses not to disclose gender", 4, true, "Prefer not to say" }
                });

            migrationBuilder.InsertData(
                table: "PositionTypes",
                columns: new[] { "Id", "DisplayOrder", "IsActive", "Level", "Name", "RequiresScope", "RoleName" },
                values: new object[,]
                {
                    { 1, 4, true, 1, "Universe Leader", true, "UniverseLeader" },
                    { 2, 5, true, 2, "Faction Leader", true, "FactionLeader" },
                    { 3, 6, true, 3, "Branch Leader", true, "BranchLeader" },
                    { 4, 8, true, 5, "Unit Leader", true, "UnitLeader" },
                    { 5, 9, true, 6, "SubUnit Leader", true, "SubUnitLeader" },
                    { 6, 1, true, 0, "Command Staff", false, "CommandStaff" },
                    { 7, 2, true, 1, "Command Staff Deputy", false, "CommandStaffDeputy" },
                    { 8, 3, true, 2, "Command Staff Assistant", false, "CommandStaffAssistant" },
                    { 9, 7, true, 4, "Branch Command", true, "BranchCommand" },
                    { 10, 10, true, 7, "Member", true, "Member" }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "Abbreviation", "BranchId", "DisplayOrder", "FactionId", "ImageUrl", "IsActive", "Level", "Name", "UniverseId" },
                values: new object[,]
                {
                    { 1, "GA", null, 1, null, null, true, 1, "Grand Admiral", null },
                    { 2, "LHA", null, 1, null, null, true, 2, "Lord High Admiral", null },
                    { 3, "HADM", null, 1, null, null, true, 3, "High Admiral", null },
                    { 4, "FADM", null, 1, null, null, true, 4, "Fleet Admiral", null },
                    { 5, "ADM", null, 1, null, null, true, 5, "Admiral", null },
                    { 6, "VADM", null, 1, null, null, true, 6, "Vice Admiral", null },
                    { 7, "RADM", null, 1, null, null, true, 7, "Rear Admiral", null },
                    { 8, "COMM", null, 1, null, null, true, 8, "Commodore", null },
                    { 9, "CPT", null, 1, null, null, true, 9, "Captain", null }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "CanonicalSpeciesId", "Description", "DisplayOrder", "FactionId", "ImageUrl", "IsActive", "Name", "UniverseId" },
                values: new object[] { 1, null, "A baseline humanoid species found throughout the galaxy.", 1, null, null, true, "Human", null });

            migrationBuilder.InsertData(
                table: "Universes",
                columns: new[] { "Id", "BBYABYAnchorDate", "Description", "DisplayFormat", "DisplayOrder", "EnableStardate", "ImageUrl", "IsActive", "Name", "OffsetYears", "StardateBaseDate", "StardateMultiplier", "UsesBBYABY", "UsesOffset" },
                values: new object[,]
                {
                    { 1, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "A galaxy far, far away", "dd MMMM yyyy", 1, false, null, true, "Star Wars", null, null, null, true, false },
                    { 2, null, "The final frontier", "ddd dd MMMM yyyy", 2, true, null, true, "Star Trek", 385, new DateTime(2323, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.7378507871321012, false, true }
                });

            migrationBuilder.InsertData(
                table: "Factions",
                columns: new[] { "Id", "Description", "DisplayOrder", "ImageUrl", "IsActive", "Name", "UniverseId" },
                values: new object[,]
                {
                    { 1, null, 1, null, true, "Galactic Empire", 1 },
                    { 2, null, 2, null, true, "Rebellion", 1 },
                    { 3, null, 1, null, true, "United Federation of Planets", 2 },
                    { 4, null, 2, null, true, "tlhIngan wo'", 2 }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Abbreviation", "BranchId", "DisplayOrder", "FactionId", "ImageUrl", "IsActive", "MaxRankId", "MaxRankLevel", "MinRankId", "MinRankLevel", "Name", "PositionTypeId", "RequiresScope", "UnitId", "UniverseId" },
                values: new object[,]
                {
                    { 1, "VCO", null, 1, null, null, true, null, 1, null, 1, "Vanguard Commander", 6, false, null, null },
                    { 2, "VXO", null, 2, null, null, true, null, 1, null, 4, "Vanguard Executive Officer", 6, false, null, null },
                    { 3, "VDO", null, 3, null, null, true, null, 1, null, 7, "Vanguard Director of Operations", 6, false, null, null },
                    { 4, "VDE", null, 4, null, null, true, null, 1, null, 7, "Vanguard Director of Engineering", 6, false, null, null },
                    { 5, "VDT", null, 5, null, null, true, null, 1, null, 7, "Vanguard Director of Training", 6, false, null, null },
                    { 6, "VDI", null, 6, null, null, true, null, 1, null, 7, "Vanguard Director of Intelligence", 6, false, null, null },
                    { 7, "VDC", null, 7, null, null, true, null, 1, null, 7, "Vanguard Director of Communications", 6, false, null, null },
                    { 8, "VDS", null, 8, null, null, true, null, 1, null, 7, "Vanguard Director of Science", 6, false, null, null },
                    { 9, "VJA", null, 9, null, null, true, null, 1, null, 7, "Vanguard Judge Advocate", 6, false, null, null },
                    { 10, "SWUL", null, 1, null, null, true, null, 1, null, 2, "Star Wars Universe Leader", 1, true, null, 1 },
                    { 51, "STUL", null, 1, null, null, true, null, 1, null, 2, "Star Trek Universe Leader", 1, true, null, 2 },
                    { 73, "DDE", null, 1, null, null, true, null, 1, null, 9, "Deputy Director of Engineering", 7, false, null, null },
                    { 74, "DDO-P", null, 1, null, null, true, null, 1, null, 9, "Deputy Director of Operations - Personnel", 7, false, null, null },
                    { 75, "DDO-T", null, 2, null, null, true, null, 1, null, 9, "Deputy Director of Operations - Tactics", 7, false, null, null },
                    { 76, "DDT", null, 1, null, null, true, null, 1, null, 9, "Deputy Director of Training", 7, false, null, null },
                    { 77, "DDI", null, 1, null, null, true, null, 1, null, 9, "Deputy Director of Intelligence", 7, false, null, null },
                    { 78, "DDC", null, 1, null, null, true, null, 1, null, 9, "Deputy Director of Communications", 7, false, null, null },
                    { 79, "DDS", null, 1, null, null, true, null, 1, null, 9, "Deputy Director of Science", 7, false, null, null },
                    { 80, "EDCA", null, 1, null, null, true, null, 1, null, 9, "Engineering Department Command Assistant", 8, false, null, null },
                    { 81, "ODCA", null, 1, null, null, true, null, 1, null, 9, "Operations Department Command Assistant", 8, false, null, null },
                    { 82, "TDCA", null, 1, null, null, true, null, 1, null, 9, "Training Department Command Assistant", 8, false, null, null },
                    { 83, "IDCA", null, 1, null, null, true, null, 1, null, 9, "Intelligence Department Command Assistant", 8, false, null, null },
                    { 84, "CDCA", null, 1, null, null, true, null, 1, null, 9, "Communications Department Command Assistant", 8, false, null, null },
                    { 85, "SDCA", null, 1, null, null, true, null, 1, null, 9, "Science Department Command Assistant", 8, false, null, null },
                    { 86, "INV", null, 1, null, null, true, null, 1, null, 9, "Investigator", 8, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Description", "DisplayOrder", "FactionId", "ImageUrl", "IsActive", "Name", "UniverseId" },
                values: new object[,]
                {
                    { 1, null, 1, 1, null, true, "Imperial Navy", 1 },
                    { 2, null, 1, 2, null, true, "Rebel Fleet", 1 },
                    { 3, null, 2, 1, null, true, "Stormtrooper Legion", 1 },
                    { 4, null, 2, 2, null, true, "Rebel Troopers", 1 },
                    { 5, null, 1, 3, null, true, "Starfleet", 2 },
                    { 6, null, 1, 4, null, true, "tlhIngan Hubbeq", 2 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "CanonicalSpeciesId", "Description", "DisplayOrder", "FactionId", "ImageUrl", "IsActive", "Name", "UniverseId" },
                values: new object[,]
                {
                    { 2, 1, null, 1, 1, null, true, "Human", 1 },
                    { 3, 1, null, 1, 2, null, true, "Human", 1 },
                    { 4, 1, null, 1, 3, null, true, "Human", 2 },
                    { 5, null, "A tall, hairy species from Kashyyyk.", 2, 2, null, true, "Wookiee", 1 },
                    { 6, null, "A logical species from the planet Vulcan.", 2, 3, null, true, "Vulcan", 2 },
                    { 7, null, "A warrior species from the planet Qo'noS.", 1, 4, null, true, "Klingon", 2 }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Abbreviation", "BranchId", "DisplayOrder", "FactionId", "ImageUrl", "IsActive", "MaxRankId", "MaxRankLevel", "MinRankId", "MinRankLevel", "Name", "PositionTypeId", "RequiresScope", "UnitId", "UniverseId" },
                values: new object[,]
                {
                    { 11, "EMP", 1, 1, 1, null, true, null, 1, null, 3, "Imperial Emperor", 2, true, null, 1 },
                    { 12, "CCIN", 1, 1, 1, null, true, null, 1, null, 3, "Commander-in-chief, Imperial Navy", 3, true, null, 1 },
                    { 13, "IPO", 1, 2, 1, null, true, null, 1, null, 3, "Imperial Personnel Officer", 9, true, null, 1 },
                    { 14, "IAC", 1, 3, 1, null, true, null, 1, null, 3, "Imperial Academy Commandant", 9, true, null, 1 },
                    { 15, "FC", 1, 4, 1, null, true, null, 1, null, 3, "Fleet Commander", 4, true, null, 1 },
                    { 16, "TFC", 1, 5, 1, null, true, null, 1, null, 4, "Taskforce Commander", 4, true, null, 1 },
                    { 17, "SCO", 1, 6, 1, null, true, null, 1, null, 5, "Ship Command Officer", 4, true, null, 1 },
                    { 18, "WC", 1, 7, 1, null, true, null, 1, null, 7, "Wing Commander", 4, true, null, 1 },
                    { 19, "SQC", 1, 8, 1, null, true, null, 1, null, 10, "Squadron Commander", 4, true, null, 1 },
                    { 20, "SFL", 1, 9, 1, null, true, null, 1, null, 12, "Squadron Flight Leader", 4, true, null, 1 },
                    { 21, "SM", 1, 10, 1, null, true, null, 1, null, 14, "Squadron Member", 10, true, null, 1 },
                    { 22, "LEC", 3, 1, 1, null, true, null, 1, null, 2, "Legion Commander", 3, true, null, 1 },
                    { 23, "SC1", 3, 2, 1, null, true, null, 1, null, 4, "Stormtrooper Command 1", 9, true, null, 1 },
                    { 24, "SC2", 3, 3, 1, null, true, null, 1, null, 4, "Stormtrooper Command 2", 9, true, null, 1 },
                    { 25, "SEC", 3, 4, 1, null, true, null, 1, null, 4, "Sector Commander", 4, true, null, 1 },
                    { 26, "BC", 3, 5, 1, null, true, null, 1, null, 5, "Battalion Commander", 4, true, null, 1 },
                    { 27, "CC", 3, 6, 1, null, true, null, 1, null, 7, "Company Commander", 4, true, null, 1 },
                    { 28, "ATL", 3, 7, 1, null, true, null, 1, null, 11, "Assault Team Leader", 4, true, null, 1 },
                    { 29, "ATX", 3, 8, 1, null, true, null, 1, null, 12, "Assault Team Executive Officer", 4, true, null, 1 },
                    { 30, "MAR", 3, 9, 1, null, true, null, 1, null, 15, "Trooper", 10, true, null, 1 },
                    { 31, "COTA", 2, 1, 2, null, true, null, 1, null, 2, "Chancellor of the Alliance", 2, true, null, 1 },
                    { 32, "AF", 2, 1, 2, null, true, null, 1, null, 2, "Admiral of the Fleet", 3, true, null, 1 },
                    { 33, "RFC1", 2, 2, 2, null, true, null, 1, null, 3, "Rebel Fleet Command 1", 9, true, null, 1 },
                    { 34, "RFC2", 2, 3, 2, null, true, null, 1, null, 3, "Rebel Fleet Command 2", 9, true, null, 1 },
                    { 35, "FC", 2, 4, 2, null, true, null, 1, null, 3, "Fleet Commander", 4, true, null, 1 },
                    { 36, "TFC", 2, 5, 2, null, true, null, 1, null, 3, "Taskforce Commander", 4, true, null, 1 },
                    { 37, "CO", 2, 6, 2, null, true, null, 1, null, 5, "Commanding Officer", 4, true, null, 1 },
                    { 38, "XO", 2, 7, 2, null, true, null, 1, null, 6, "Executive Officer", 4, true, null, 1 },
                    { 39, "DH", 2, 8, 2, null, true, null, 1, null, 8, "Department Head", 4, true, null, 1 },
                    { 40, "OF", 2, 9, 2, null, true, null, 1, null, 10, "Officer", 10, true, null, 1 },
                    { 41, "CGEN", 4, 1, 2, null, true, null, 1, null, 2, "Commanding General", 3, true, null, 1 },
                    { 42, "RTC1", 4, 2, 2, null, true, null, 1, null, 4, "Rebel Trooper Command 1", 9, true, null, 1 },
                    { 43, "RTC2", 4, 3, 2, null, true, null, 1, null, 4, "Rebel Trooper Command 2", 9, true, null, 1 },
                    { 44, "SDC", 4, 4, 2, null, true, null, 1, null, 4, "Sector Division Commander", 4, true, null, 1 },
                    { 45, "FDC", 4, 5, 2, null, true, null, 1, null, 5, "Fleet Division Commander", 4, true, null, 1 },
                    { 46, "BL", 4, 6, 2, null, true, null, 1, null, 7, "Brigade Leader", 4, true, null, 1 },
                    { 47, "CL", 4, 7, 2, null, true, null, 1, null, 8, "Company Leader", 4, true, null, 1 },
                    { 48, "TL", 4, 8, 2, null, true, null, 1, null, 11, "Troop Leader", 4, true, null, 1 },
                    { 49, "TD", 4, 9, 2, null, true, null, 1, null, 12, "Troop Deputy", 4, true, null, 1 },
                    { 50, "SOL", 4, 10, 2, null, true, null, 1, null, 15, "Solider", 10, true, null, 1 },
                    { 52, "PRES", 5, 1, 3, null, true, null, 1, null, 3, "President of the United Federation of Planets", 2, true, null, 2 },
                    { 53, "CSO", 5, 1, 3, null, true, null, 1, null, 3, "Chief of Starfleet Operations", 3, true, null, 2 },
                    { 54, "CSP", 5, 2, 3, null, true, null, 1, null, 3, "Chief of Starfleet Personnel and Training", 9, true, null, 2 },
                    { 55, "CSSE", 5, 3, 3, null, true, null, 1, null, 3, "Chief of Starfleet Science and Exploration", 9, true, null, 2 },
                    { 56, "SC", 5, 4, 3, null, true, null, 1, null, 3, "Sector Commander", 4, true, null, 2 },
                    { 57, "FC", 5, 5, 3, null, true, null, 1, null, 4, "Fleet Commander", 4, true, null, 2 },
                    { 58, "TFC", 5, 6, 3, null, true, null, 1, null, 5, "Taskforce Commander", 4, true, null, 2 },
                    { 59, "CO", 5, 7, 3, null, true, null, 1, null, 7, "Commanding Officer", 4, true, null, 2 },
                    { 60, "XO", 5, 8, 3, null, true, null, 1, null, 8, "Executive Officer", 4, true, null, 2 },
                    { 61, "DH", 5, 9, 3, null, true, null, 1, null, 9, "Department Head", 4, true, null, 2 },
                    { 62, "OF", 5, 10, 3, null, true, null, 1, null, 12, "Officer", 10, true, null, 2 },
                    { 63, "PAQ", 6, 1, 4, null, true, null, 1, null, 2, "paQ'dIj", 2, true, null, 2 },
                    { 64, "SCTH", 6, 1, 4, null, true, null, 1, null, 2, "Supreme Commander, tlhIngan Hubbeq", 3, true, null, 2 },
                    { 65, "POTH", 6, 2, 4, null, true, null, 1, null, 3, "Personnel Officer, tlhIngan Hubbeq", 9, true, null, 2 },
                    { 66, "BOTH", 6, 3, 4, null, true, null, 1, null, 3, "Battle Officer, tlhIngan Hubbeq", 9, true, null, 2 },
                    { 67, "FC", 6, 4, 4, null, true, null, 1, null, 4, "Fleet Commander", 4, true, null, 2 },
                    { 68, "TGC", 6, 5, 4, null, true, null, 1, null, 5, "Taskgroup Commander", 4, true, null, 2 },
                    { 69, "CO", 6, 6, 4, null, true, null, 1, null, 7, "Commanding Officer", 4, true, null, 2 },
                    { 70, "XO", 6, 7, 4, null, true, null, 1, null, 8, "Executive Officer", 4, true, null, 2 },
                    { 71, "DH", 6, 8, 4, null, true, null, 1, null, 9, "Department Head", 4, true, null, 2 },
                    { 72, "OF", 6, 1, 4, null, true, null, 1, null, 12, "Officer", 10, true, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "Abbreviation", "BranchId", "DisplayOrder", "FactionId", "ImageUrl", "IsActive", "Level", "Name", "UniverseId" },
                values: new object[,]
                {
                    { 10, "FADM", 1, 1, 1, null, true, 1, "Fleet Admiral", 1 },
                    { 11, "ADM", 1, 2, 1, null, true, 2, "Admiral", 1 },
                    { 12, "VADM", 1, 3, 1, null, true, 3, "Vice Admiral", 1 },
                    { 13, "RADM", 1, 4, 1, null, true, 4, "Rear Admiral", 1 },
                    { 14, "COM", 1, 5, 1, null, true, 5, "Commodore", 1 },
                    { 15, "COL", 1, 6, 1, null, true, 6, "Colonel", 1 },
                    { 16, "LTCOL", 1, 7, 1, null, true, 7, "Lieutenant Colonel", 1 },
                    { 17, "MAJ", 1, 8, 1, null, true, 8, "Major", 1 },
                    { 18, "CPT", 1, 9, 1, null, true, 9, "Captain", 1 },
                    { 19, "COM", 1, 10, 1, null, true, 10, "Commander", 1 },
                    { 20, "LTCOM", 1, 11, 1, null, true, 11, "Lieutenant Commander", 1 },
                    { 21, "LT", 1, 12, 1, null, true, 12, "Lieutenant", 1 },
                    { 22, "SLT", 1, 13, 1, null, true, 13, "Sub-Lieutenant", 1 },
                    { 23, "ENS", 1, 14, 1, null, true, 14, "Ensign", 1 },
                    { 24, "LEGEN", 3, 1, 1, null, true, 1, "Legion General", 1 },
                    { 25, "HGEN", 3, 2, 1, null, true, 2, "High General", 1 },
                    { 26, "GEN", 3, 3, 1, null, true, 3, "General", 1 },
                    { 27, "LGEN", 3, 4, 1, null, true, 4, "Lieutenant General", 1 },
                    { 28, "MGEN", 3, 5, 1, null, true, 5, "Major General", 1 },
                    { 29, "BGEN", 3, 6, 1, null, true, 6, "Brigadier General", 1 },
                    { 30, "COL", 3, 7, 1, null, true, 7, "Colonel", 1 },
                    { 31, "LTCOL", 3, 8, 1, null, true, 8, "Lieutenant Colonel", 1 },
                    { 32, "MAJ", 3, 9, 1, null, true, 9, "Major", 1 },
                    { 33, "CPT", 3, 10, 1, null, true, 10, "Captain", 1 },
                    { 34, "1LT", 3, 11, 1, null, true, 11, "First Lieutenant", 1 },
                    { 35, "2LT", 3, 12, 1, null, true, 12, "Second Lieutenant", 1 },
                    { 36, "SGT", 3, 13, 1, null, true, 13, "Sergeant", 1 },
                    { 37, "CPL", 3, 14, 1, null, true, 14, "Corporal", 1 },
                    { 38, "PVT", 3, 15, 1, null, true, 15, "Private", 1 },
                    { 39, "ADM", 2, 1, 2, null, true, 1, "Admiral", 1 },
                    { 40, "VADM", 2, 2, 2, null, true, 2, "Vice Admiral", 1 },
                    { 41, "RADM", 2, 3, 2, null, true, 3, "Rear Admiral", 1 },
                    { 42, "COM", 2, 4, 2, null, true, 4, "Commodore", 1 },
                    { 43, "CPT", 2, 5, 2, null, true, 5, "Captain", 1 },
                    { 44, "COM", 2, 6, 2, null, true, 6, "Commander", 1 },
                    { 45, "LTCOM", 2, 7, 2, null, true, 7, "Lieutenant Commander", 1 },
                    { 46, "LT", 2, 8, 2, null, true, 8, "Lieutenant", 1 },
                    { 47, "LTJG", 2, 9, 2, null, true, 9, "Lieutenant Junior Grade", 1 },
                    { 48, "ENS", 2, 10, 2, null, true, 10, "Ensign", 1 },
                    { 49, "TGEN", 4, 1, 2, null, true, 1, "Trooper General", 1 },
                    { 50, "GEN", 4, 2, 2, null, true, 2, "General", 1 },
                    { 51, "LGEN", 4, 3, 2, null, true, 3, "Lieutenant General", 1 },
                    { 52, "MGEN", 4, 4, 2, null, true, 4, "Major General", 1 },
                    { 53, "BGEN", 4, 5, 2, null, true, 5, "Brigadier General", 1 },
                    { 54, "COL", 4, 6, 2, null, true, 6, "Colonel", 1 },
                    { 55, "LTCOL", 4, 7, 2, null, true, 7, "Lieutenant Colonel", 1 },
                    { 56, "MAJ", 4, 8, 2, null, true, 8, "Major", 1 },
                    { 57, "CPT", 4, 9, 2, null, true, 9, "Captain", 1 },
                    { 58, "LT", 4, 10, 2, null, true, 10, "Lieutenant", 1 },
                    { 59, "OC", 4, 11, 2, null, true, 11, "Officer Cadet", 1 },
                    { 60, "SGT", 4, 12, 2, null, true, 12, "Sergeant", 1 },
                    { 61, "CPL", 4, 13, 2, null, true, 13, "Corporal", 1 },
                    { 62, "PVT", 4, 14, 2, null, true, 14, "Private", 1 },
                    { 63, "FADM", 5, 1, 3, null, true, 1, "Fleet Admiral", 2 },
                    { 64, "ADM", 5, 2, 3, null, true, 2, "Admiral", 2 },
                    { 65, "VADM", 5, 3, 3, null, true, 3, "Vice Admiral", 2 },
                    { 66, "RADM", 5, 4, 3, null, true, 4, "Rear Admiral", 2 },
                    { 67, "COM", 5, 5, 3, null, true, 5, "Commodore", 2 },
                    { 68, "CPT", 5, 6, 3, null, true, 6, "Captain", 2 },
                    { 69, "COM", 5, 7, 3, null, true, 7, "Commander", 2 },
                    { 70, "LTCOM", 5, 8, 3, null, true, 8, "Lieutenant Commander", 2 },
                    { 71, "LT", 5, 9, 3, null, true, 9, "Lieutenant", 2 },
                    { 72, "LTJG", 5, 10, 3, null, true, 10, "Lieutenant Junior Grade", 2 },
                    { 73, "ENS", 5, 11, 3, null, true, 11, "Ensign", 2 },
                    { 74, "CDT", 5, 12, 3, null, true, 12, "Cadet", 2 },
                    { 75, "AJYO", 6, 1, 4, null, true, 1, "'ajyo'", 2 },
                    { 76, "AJ", 6, 2, 4, null, true, 2, "'aj", 2 },
                    { 77, "TOT", 6, 3, 4, null, true, 3, "totlh", 2 },
                    { 78, "HODG", 6, 4, 4, null, true, 4, "HoDghom", 2 },
                    { 79, "HODY", 6, 5, 4, null, true, 5, "HoDyo'", 2 },
                    { 80, "HOD", 6, 6, 4, null, true, 6, "HoD", 2 },
                    { 81, "LA", 6, 7, 4, null, true, 7, "la'", 2 },
                    { 82, "SOG", 6, 8, 4, null, true, 8, "Sogh", 2 },
                    { 83, "DEV", 6, 9, 4, null, true, 9, "DevwI'", 2 },
                    { 84, "DA", 6, 10, 4, null, true, 10, "Da'", 2 },
                    { 85, "BE", 6, 11, 4, null, true, 11, "beq", 2 },
                    { 86, "RE", 6, 12, 4, null, true, 12, "rewbe'", 2 }
                });

            migrationBuilder.InsertData(
                table: "ShipClasses",
                columns: new[] { "Id", "Abbreviation", "BranchId", "Description", "DisplayOrder", "FactionId", "IsActive", "Name", "UniverseId" },
                values: new object[,]
                {
                    { 1, "ISDII", 1, null, 1, 1, true, "Imperial II-class Star Destroyer", 1 },
                    { 2, "Sovereign", 5, null, 2, 3, true, "Akira-class", 2 },
                    { 3, "Akira", 5, null, 3, 3, true, "Sovereign-class", 2 },
                    { 4, "MC75", 2, null, 4, 2, true, "MC75 Star Cruiser", 1 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "BranchId", "Description", "DisplayOrder", "FactionId", "ImageUrl", "IsActive", "Name", "ParentUnitId", "ShipId", "UniverseId" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 1, null, true, "1st Sector Fleet", null, null, 1 },
                    { 7, 5, null, 1, 3, null, true, "Fifth Fleet", null, null, 2 },
                    { 11, 3, null, 1, 1, null, true, "15th Stormtrooper Legion", null, null, 1 },
                    { 15, 2, null, 1, 2, null, true, "6th Rebel Fleet", null, null, 1 },
                    { 20, 6, null, 1, 4, null, true, "Strike Fleet Qapla'", null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Ship",
                columns: new[] { "Id", "Abbreviation", "BranchId", "Description", "DisplayOrder", "FactionId", "IsActive", "Name", "ShipClassId", "ShipRegistry", "UniverseId" },
                values: new object[,]
                {
                    { 1, "Devastator", 1, null, 1, 1, true, "ISD Devastator", 1, null, 1 },
                    { 2, "Avalon", 5, null, 2, 3, true, "USS Avalon", 2, "NCC-71854", 2 },
                    { 3, "Venture", 5, null, 3, 3, true, "USS Venture", 3, "NCC-63887", 2 },
                    { 4, null, 2, null, 4, 2, true, "Harmony", 4, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "BranchId", "Description", "DisplayOrder", "FactionId", "ImageUrl", "IsActive", "Name", "ParentUnitId", "ShipId", "UniverseId" },
                values: new object[,]
                {
                    { 8, 5, null, 2, 3, null, true, "3rd Cruiser Wing", 7, null, 2 },
                    { 12, 3, null, 2, 1, null, true, "1st Cohort", 11, null, 1 },
                    { 16, 2, null, 2, 2, null, true, "Vanguard Task Group", 15, null, 1 },
                    { 22, 6, null, 3, 4, null, true, "Strike Wing SuvwI'", 20, null, 2 },
                    { 2, 1, null, 2, 1, null, true, "ISD Devastator", 1, 1, 1 },
                    { 9, 5, null, 3, 3, null, true, "USS Avalon", 8, 2, 2 },
                    { 10, 5, null, 4, 3, null, true, "USS Venture", 8, 3, 2 },
                    { 13, 3, null, 3, 1, null, true, "Aurek Century", 12, null, 1 },
                    { 17, 2, null, 3, 2, null, true, "Harmony", 16, 4, 1 },
                    { 3, 1, null, 3, 1, null, true, "10th Attack Wing", 2, null, 1 },
                    { 14, 3, null, 4, 1, null, true, "Alpha Phalanx", 13, null, 1 },
                    { 18, 2, null, 4, 2, null, true, "Red Wing", 17, null, 1 },
                    { 4, 1, null, 4, 1, null, true, "14th Bombardment Wing", 3, null, 1 },
                    { 19, 2, null, 5, 2, null, true, "Rogue Squadron", 18, null, 1 },
                    { 5, 1, null, 5, 1, null, true, "116th Fighter Squadron", 4, null, 1 },
                    { 6, 1, null, 6, 1, null, true, "12th Bomber Squadron", 4, null, 1 },
                    { 21, 6, null, 2, 4, null, true, "Raiding Group Mogh", 19, null, 2 },
                    { 23, 6, null, 4, 4, null, true, "Blade Flight K'Tok", 21, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DisplayOrder",
                table: "Branches",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_FactionId_DisplayOrder",
                table: "Branches",
                columns: new[] { "FactionId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_UniverseId",
                table: "Branches",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BranchId",
                table: "Characters",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterTypeId",
                table: "Characters",
                column: "CharacterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_FactionId",
                table: "Characters",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GenderId",
                table: "Characters",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MemberId",
                table: "Characters",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PositionId",
                table: "Characters",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RankId",
                table: "Characters",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SpeciesId",
                table: "Characters",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UnitId",
                table: "Characters",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UniverseId",
                table: "Characters",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_DisplayOrder",
                table: "Factions",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_Name",
                table: "Factions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factions_UniverseId_DisplayOrder",
                table: "Factions",
                columns: new[] { "UniverseId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genders_DisplayOrder",
                table: "Genders",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Name",
                table: "Genders",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Npc_BranchId",
                table: "Npc",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Npc_CharacterTypeId",
                table: "Npc",
                column: "CharacterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Npc_FactionId",
                table: "Npc",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Npc_GenderId",
                table: "Npc",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Npc_RankId",
                table: "Npc",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Npc_SpeciesId",
                table: "Npc",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Npc_UnitId",
                table: "Npc",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Npc_UniverseId",
                table: "Npc",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_BranchId",
                table: "Positions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_FactionId",
                table: "Positions",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_MaxRankId",
                table: "Positions",
                column: "MaxRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_MinRankId",
                table: "Positions",
                column: "MinRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PositionTypeId",
                table: "Positions",
                column: "PositionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_UnitId",
                table: "Positions",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_UniverseId",
                table: "Positions",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionTypes_DisplayOrder",
                table: "PositionTypes",
                column: "DisplayOrder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PositionTypes_Name",
                table: "PositionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PositionTypes_RoleName",
                table: "PositionTypes",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_BranchId_DisplayOrder",
                table: "Ranks",
                columns: new[] { "BranchId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_DisplayOrder",
                table: "Ranks",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_FactionId",
                table: "Ranks",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_UniverseId",
                table: "Ranks",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_Ship_BranchId_DisplayOrder",
                table: "Ship",
                columns: new[] { "BranchId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ship_DisplayOrder",
                table: "Ship",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Ship_FactionId",
                table: "Ship",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ship_ShipClassId",
                table: "Ship",
                column: "ShipClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Ship_UniverseId",
                table: "Ship",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipClasses_BranchId_DisplayOrder",
                table: "ShipClasses",
                columns: new[] { "BranchId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShipClasses_DisplayOrder",
                table: "ShipClasses",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_ShipClasses_FactionId",
                table: "ShipClasses",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipClasses_UniverseId",
                table: "ShipClasses",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_CanonicalSpeciesId",
                table: "Species",
                column: "CanonicalSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_DisplayOrder",
                table: "Species",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Species_FactionId_DisplayOrder",
                table: "Species",
                columns: new[] { "FactionId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Species_Name_UniverseId_FactionId",
                table: "Species",
                columns: new[] { "Name", "UniverseId", "FactionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Species_UniverseId",
                table: "Species",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_BranchId_DisplayOrder",
                table: "Units",
                columns: new[] { "BranchId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_DisplayOrder",
                table: "Units",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Units_FactionId",
                table: "Units",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ParentUnitId",
                table: "Units",
                column: "ParentUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ShipId",
                table: "Units",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UniverseId",
                table: "Units",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_Universes_DisplayOrder",
                table: "Universes",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Universes_Name",
                table: "Universes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Npc");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "CharacterTypes");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "PositionTypes");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Ship");

            migrationBuilder.DropTable(
                name: "ShipClasses");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Universes");
        }
    }
}
