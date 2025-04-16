using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vanguard.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddICDateSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BBYABYAnchorDate",
                table: "Universes",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayFormat",
                table: "Universes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "EnableStardate",
                table: "Universes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OffsetYears",
                table: "Universes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StardateBaseDate",
                table: "Universes",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StardateMultiplier",
                table: "Universes",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UsesBBYABY",
                table: "Universes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UsesOffset",
                table: "Universes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Universes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BBYABYAnchorDate", "DisplayFormat", "EnableStardate", "OffsetYears", "StardateBaseDate", "StardateMultiplier", "UsesBBYABY", "UsesOffset" },
                values: new object[] { new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "dd MMMM yyyy", false, null, null, null, true, false });

            migrationBuilder.UpdateData(
                table: "Universes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BBYABYAnchorDate", "DisplayFormat", "EnableStardate", "OffsetYears", "StardateBaseDate", "StardateMultiplier", "UsesBBYABY", "UsesOffset" },
                values: new object[] { null, "dd MMMM yyyy", true, 385, new DateTime(2323, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.7378507871321012, false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BBYABYAnchorDate",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "DisplayFormat",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "EnableStardate",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "OffsetYears",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "StardateBaseDate",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "StardateMultiplier",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "UsesBBYABY",
                table: "Universes");

            migrationBuilder.DropColumn(
                name: "UsesOffset",
                table: "Universes");
        }
    }
}
