using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vanguard.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedPositionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Branches_BranchId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Factions_FactionId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Units_UnitId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Branches_BranchId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Factions_FactionId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Units_UnitId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "BranchParentId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "FactionParentId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UniverseParentId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Positions");

            migrationBuilder.AddColumn<int>(
                name: "ParentUnitId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PositionTypeId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PositionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PositionTypes",
                columns: new[] { "Id", "Level", "Name", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, "Universe Leader", "UniverseLeader" },
                    { 2, 2, "Faction Leader", "FactionLeader" },
                    { 3, 3, "Branch Leader", "BranchLeader" },
                    { 4, 4, "Unit Leader", "UnitLeader" },
                    { 5, 5, "SubUnit Leader", "SubUnitLeader" },
                    { 6, 0, "Command Staff", "CommandStaff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_ParentUnitId",
                table: "Units",
                column: "ParentUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PositionTypeId",
                table: "Positions",
                column: "PositionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Branches_BranchId",
                table: "Characters",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Factions_FactionId",
                table: "Characters",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Units_UnitId",
                table: "Characters",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Branches_BranchId",
                table: "Positions",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Factions_FactionId",
                table: "Positions",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_PositionTypes_PositionTypeId",
                table: "Positions",
                column: "PositionTypeId",
                principalTable: "PositionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Units_UnitId",
                table: "Positions",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Units_ParentUnitId",
                table: "Units",
                column: "ParentUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Branches_BranchId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Factions_FactionId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Units_UnitId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Branches_BranchId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Factions_FactionId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_PositionTypes_PositionTypeId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Units_UnitId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Units_ParentUnitId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "PositionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Units_ParentUnitId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Positions_PositionTypeId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "ParentUnitId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PositionTypeId",
                table: "Positions");

            migrationBuilder.AddColumn<int>(
                name: "BranchParentId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Units",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "FactionParentId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Units",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UniverseParentId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Positions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactionId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Branches_BranchId",
                table: "Characters",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Factions_FactionId",
                table: "Characters",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Units_UnitId",
                table: "Characters",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Branches_BranchId",
                table: "Positions",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Factions_FactionId",
                table: "Positions",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Units_UnitId",
                table: "Positions",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
