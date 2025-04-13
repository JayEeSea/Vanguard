using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vanguard.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Factions_FactionId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Universes_UniverseId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AspNetUsers_MemberId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Genders_GenderId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Positions_PositionId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Ranks_RankId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Species_SpeciesId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Universes_UniverseId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Factions_Universes_UniverseId",
                table: "Factions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_PositionTypes_PositionTypeId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Ranks_MaxRankId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Ranks_MinRankId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Universes_UniverseId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Branches_BranchId",
                table: "Ranks");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Factions_FactionId",
                table: "Ranks");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Universes_UniverseId",
                table: "Ranks");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Factions_FactionId",
                table: "Species");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Universes_UniverseId",
                table: "Species");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Branches_BranchId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Universes_UniverseId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_BranchId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Species_FactionId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Ranks_BranchId",
                table: "Ranks");

            migrationBuilder.DropIndex(
                name: "IX_Factions_UniverseId",
                table: "Factions");

            migrationBuilder.DropIndex(
                name: "IX_Branches_FactionId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "FactionParentId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "UniverseParentId",
                table: "Factions");

            migrationBuilder.DropColumn(
                name: "FactionParentId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "UniverseParentId",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "UniverseParentId",
                table: "Species",
                newName: "DisplayOrder");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Universes",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Universes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Universes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Units",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Units",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Units",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Species",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Species",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Species",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CanonicalSpeciesId",
                table: "Species",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Species",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Ranks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Ranks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Ranks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Ranks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Ranks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Ranks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "PositionTypes",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PositionTypes",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "PositionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PositionTypes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresScope",
                table: "PositionTypes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PositionTypeId",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MinRankLevel",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MinRankId",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaxRankLevel",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaxRankId",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Positions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Positions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Positions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "RequiresScope",
                table: "Positions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genders",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Genders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Genders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Genders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Factions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Factions",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Factions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Factions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RankId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PlaceOfBirth",
                table: "Characters",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Personality",
                table: "Characters",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "Characters",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Characters",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Background",
                table: "Characters",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Appearance",
                table: "Characters",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Characters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Branches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Branches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Branches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Branches",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "TimeZone",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DisplayOrder", "IsActive", "RequiresScope" },
                values: new object[] { 4, true, true });

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DisplayOrder", "IsActive", "RequiresScope" },
                values: new object[] { 5, true, true });

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DisplayOrder", "IsActive", "RequiresScope" },
                values: new object[] { 6, true, true });

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DisplayOrder", "IsActive", "Level", "RequiresScope" },
                values: new object[] { 8, true, 5, true });

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DisplayOrder", "IsActive", "Level", "RequiresScope" },
                values: new object[] { 9, true, 6, true });

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DisplayOrder", "IsActive", "RequiresScope" },
                values: new object[] { 1, true, false });

            migrationBuilder.InsertData(
                table: "PositionTypes",
                columns: new[] { "Id", "DisplayOrder", "IsActive", "Level", "Name", "RequiresScope", "RoleName" },
                values: new object[,]
                {
                    { 7, 2, true, 1, "Command Staff Deputy", false, "CommandStaffDeputy" },
                    { 8, 3, true, 2, "Command Staff Assistant", false, "CommandStaffAssistant" },
                    { 9, 7, true, 4, "Branch Command", true, "BranchCommand" },
                    { 10, 10, true, 7, "Member", true, "Member" }
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
                    { 9, "VJA", null, 9, null, null, true, null, 1, null, 7, "Vanguard Judge Advocate", 6, false, null, null }
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
                columns: new[] { "Id", "Description", "DisplayOrder", "ImageUrl", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "A galaxy far, far away", 1, null, true, "Star Wars" },
                    { 2, "The final frontier", 2, null, true, "Star Trek" }
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
                table: "Units",
                columns: new[] { "Id", "BranchId", "Description", "DisplayOrder", "FactionId", "ImageUrl", "IsActive", "Name", "ParentUnitId", "UniverseId" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 1, null, true, "1st Sector Fleet", null, 1 },
                    { 7, 5, null, 1, 3, null, true, "Fifth Fleet", null, 2 },
                    { 11, 3, null, 1, 1, null, true, "15th Stormtrooper Legion", null, 1 },
                    { 15, 2, null, 1, 2, null, true, "6th Rebel Fleet", null, 1 },
                    { 19, 6, null, 1, 4, null, true, "Strike Fleet Qapla'", null, 2 },
                    { 2, 1, null, 2, 1, null, true, "ISD Devastator", 1, 1 },
                    { 8, 5, null, 2, 3, null, true, "3rd Cruiser Wing", 7, 2 },
                    { 12, 3, null, 2, 1, null, true, "1st Cohort", 11, 1 },
                    { 16, 2, null, 2, 2, null, true, "Vanguard Task Group", 15, 1 },
                    { 20, 6, null, 2, 4, null, true, "Raiding Group Mogh", 19, 2 },
                    { 3, 1, null, 3, 2, null, true, "10th Attack Wing", 2, 1 },
                    { 9, 5, null, 3, 3, null, true, "USS Avalon", 8, 2 },
                    { 10, 5, null, 4, 3, null, true, "USS Venture", 8, 2 },
                    { 13, 3, null, 3, 1, null, true, "Aurek Century", 12, 1 },
                    { 17, 2, null, 3, 2, null, true, "Red Wing", 16, 1 },
                    { 18, 2, null, 4, 2, null, true, "Rogue Squadron", 16, 1 },
                    { 21, 6, null, 3, 4, null, true, "Strike Wing SuvwI'", 20, 2 },
                    { 4, 1, null, 4, 2, null, true, "14th Bombardment Wing", 3, 1 },
                    { 14, 3, null, 4, 1, null, true, "Alpha Phalanx", 13, 1 },
                    { 22, 6, null, 4, 4, null, true, "Blade Flight K'Tok", 21, 2 },
                    { 5, 1, null, 5, 2, null, true, "116th Fighter Squadron", 4, 1 },
                    { 6, 1, null, 6, 2, null, true, "12th Bomber Squadron", 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Universes_DisplayOrder",
                table: "Universes",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Universes_Name",
                table: "Universes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_BranchId_DisplayOrder",
                table: "Units",
                columns: new[] { "BranchId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_DisplayOrder",
                table: "Units",
                column: "DisplayOrder");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Unit_UniverseAndFactionAndBranchRequired",
                table: "Units",
                sql: "UniverseId IS NOT NULL AND FactionId IS NOT NULL AND BranchId IS NOT NULL");

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

            migrationBuilder.AddCheckConstraint(
                name: "CK_Species_ScopeOrGlobal",
                table: "Species",
                sql: "(UniverseId IS NOT NULL AND FactionId IS NOT NULL) OR (UniverseId IS NULL AND FactionId IS NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_BranchId_DisplayOrder",
                table: "Ranks",
                columns: new[] { "BranchId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_DisplayOrder",
                table: "Ranks",
                column: "DisplayOrder");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Rank_ScopeOrGlobal",
                table: "Ranks",
                sql: "(UniverseId IS NOT NULL AND FactionId IS NOT NULL AND BranchId IS NOT NULL) OR (UniverseId IS NULL AND FactionId IS NULL AND BranchId IS NULL)");

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

            migrationBuilder.AddCheckConstraint(
                name: "CK_Position_RequiresScopeFields",
                table: "Positions",
                sql: "(RequiresScope = 0) OR (UniverseId IS NOT NULL)");

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

            migrationBuilder.AddCheckConstraint(
                name: "CK_Faction_UniverseRequired",
                table: "Factions",
                sql: "UniverseId IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DisplayOrder",
                table: "Branches",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_FactionId_DisplayOrder",
                table: "Branches",
                columns: new[] { "FactionId", "DisplayOrder" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Branch_UniverseAndFactionRequired",
                table: "Branches",
                sql: "UniverseId IS NOT NULL AND FactionId IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Factions_FactionId",
                table: "Branches",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Universes_UniverseId",
                table: "Branches",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AspNetUsers_MemberId",
                table: "Characters",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Genders_GenderId",
                table: "Characters",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Positions_PositionId",
                table: "Characters",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Ranks_RankId",
                table: "Characters",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Species_SpeciesId",
                table: "Characters",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Universes_UniverseId",
                table: "Characters",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factions_Universes_UniverseId",
                table: "Factions",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_PositionTypes_PositionTypeId",
                table: "Positions",
                column: "PositionTypeId",
                principalTable: "PositionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Ranks_MaxRankId",
                table: "Positions",
                column: "MaxRankId",
                principalTable: "Ranks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Ranks_MinRankId",
                table: "Positions",
                column: "MinRankId",
                principalTable: "Ranks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Universes_UniverseId",
                table: "Positions",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Branches_BranchId",
                table: "Ranks",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Factions_FactionId",
                table: "Ranks",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Universes_UniverseId",
                table: "Ranks",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Factions_FactionId",
                table: "Species",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Species_CanonicalSpeciesId",
                table: "Species",
                column: "CanonicalSpeciesId",
                principalTable: "Species",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Universes_UniverseId",
                table: "Species",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Branches_BranchId",
                table: "Units",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Universes_UniverseId",
                table: "Units",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Factions_FactionId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Universes_UniverseId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AspNetUsers_MemberId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Genders_GenderId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Positions_PositionId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Ranks_RankId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Species_SpeciesId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Universes_UniverseId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Factions_Universes_UniverseId",
                table: "Factions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_PositionTypes_PositionTypeId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Ranks_MaxRankId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Ranks_MinRankId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Universes_UniverseId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Branches_BranchId",
                table: "Ranks");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Factions_FactionId",
                table: "Ranks");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Universes_UniverseId",
                table: "Ranks");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Factions_FactionId",
                table: "Species");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Species_CanonicalSpeciesId",
                table: "Species");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Universes_UniverseId",
                table: "Species");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Branches_BranchId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Universes_UniverseId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Universes_DisplayOrder",
                table: "Universes");

            migrationBuilder.DropIndex(
                name: "IX_Universes_Name",
                table: "Universes");

            migrationBuilder.DropIndex(
                name: "IX_Units_BranchId_DisplayOrder",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_DisplayOrder",
                table: "Units");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Unit_UniverseAndFactionAndBranchRequired",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Species_CanonicalSpeciesId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_DisplayOrder",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_FactionId_DisplayOrder",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_Name_UniverseId_FactionId",
                table: "Species");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Species_ScopeOrGlobal",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Ranks_BranchId_DisplayOrder",
                table: "Ranks");

            migrationBuilder.DropIndex(
                name: "IX_Ranks_DisplayOrder",
                table: "Ranks");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Rank_ScopeOrGlobal",
                table: "Ranks");

            migrationBuilder.DropIndex(
                name: "IX_PositionTypes_DisplayOrder",
                table: "PositionTypes");

            migrationBuilder.DropIndex(
                name: "IX_PositionTypes_Name",
                table: "PositionTypes");

            migrationBuilder.DropIndex(
                name: "IX_PositionTypes_RoleName",
                table: "PositionTypes");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Position_RequiresScopeFields",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Genders_DisplayOrder",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Genders_Name",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Factions_DisplayOrder",
                table: "Factions");

            migrationBuilder.DropIndex(
                name: "IX_Factions_Name",
                table: "Factions");

            migrationBuilder.DropIndex(
                name: "IX_Factions_UniverseId_DisplayOrder",
                table: "Factions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Faction_UniverseRequired",
                table: "Factions");

            migrationBuilder.DropIndex(
                name: "IX_Branches_DisplayOrder",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_FactionId_DisplayOrder",
                table: "Branches");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Branch_UniverseAndFactionRequired",
                table: "Branches");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Universes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Universes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "CanonicalSpeciesId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "PositionTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PositionTypes");

            migrationBuilder.DropColumn(
                name: "RequiresScope",
                table: "PositionTypes");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "RequiresScope",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Factions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Factions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Species",
                newName: "UniverseParentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Universes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Species",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactionParentId",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Ranks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Ranks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Ranks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "PositionTypes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PositionTypes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionTypeId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinRankLevel",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinRankId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxRankLevel",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxRankId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genders",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Factions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Factions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UniverseParentId",
                table: "Factions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RankId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "PlaceOfBirth",
                keyValue: null,
                column: "PlaceOfBirth",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PlaceOfBirth",
                table: "Characters",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Personality",
                keyValue: null,
                column: "Personality",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Personality",
                table: "Characters",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "MemberId",
                keyValue: null,
                column: "MemberId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "Characters",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "FullName",
                keyValue: null,
                column: "FullName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Characters",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Background",
                keyValue: null,
                column: "Background",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Background",
                table: "Characters",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Appearance",
                keyValue: null,
                column: "Appearance",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Appearance",
                table: "Characters",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UniverseId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactionParentId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniverseParentId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "TimeZone",
                keyValue: null,
                column: "TimeZone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TimeZone",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Location",
                keyValue: null,
                column: "Location",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Level",
                value: 4);

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Level",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Units_BranchId",
                table: "Units",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_FactionId",
                table: "Species",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_BranchId",
                table: "Ranks",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_UniverseId",
                table: "Factions",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_FactionId",
                table: "Branches",
                column: "FactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Factions_FactionId",
                table: "Branches",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Universes_UniverseId",
                table: "Branches",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AspNetUsers_MemberId",
                table: "Characters",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Genders_GenderId",
                table: "Characters",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Positions_PositionId",
                table: "Characters",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Ranks_RankId",
                table: "Characters",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Species_SpeciesId",
                table: "Characters",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Universes_UniverseId",
                table: "Characters",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factions_Universes_UniverseId",
                table: "Factions",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_PositionTypes_PositionTypeId",
                table: "Positions",
                column: "PositionTypeId",
                principalTable: "PositionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Ranks_MaxRankId",
                table: "Positions",
                column: "MaxRankId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Ranks_MinRankId",
                table: "Positions",
                column: "MinRankId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Universes_UniverseId",
                table: "Positions",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Branches_BranchId",
                table: "Ranks",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Factions_FactionId",
                table: "Ranks",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Universes_UniverseId",
                table: "Ranks",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Factions_FactionId",
                table: "Species",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Universes_UniverseId",
                table: "Species",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Branches_BranchId",
                table: "Units",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Universes_UniverseId",
                table: "Units",
                column: "UniverseId",
                principalTable: "Universes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
