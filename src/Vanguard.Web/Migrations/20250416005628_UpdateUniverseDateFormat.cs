using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vanguard.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUniverseDateFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Universes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DisplayFormat",
                value: "ddd dd MMMM yyyy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Universes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DisplayFormat",
                value: "dd MMMM yyyy");
        }
    }
}
