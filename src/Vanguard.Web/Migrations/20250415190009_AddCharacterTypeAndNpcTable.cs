using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vanguard.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterTypeAndNpcTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterTypeId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "CharacterTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Player" },
                    { 2, "NPC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterTypeId",
                table: "Characters",
                column: "CharacterTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterTypes_CharacterTypeId",
                table: "Characters",
                column: "CharacterTypeId",
                principalTable: "CharacterTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterTypes_CharacterTypeId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Npc");

            migrationBuilder.DropTable(
                name: "CharacterTypes");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharacterTypeId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharacterTypeId",
                table: "Characters");
        }
    }
}
