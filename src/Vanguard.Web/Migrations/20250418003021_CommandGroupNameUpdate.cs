using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vanguard.Web.Migrations
{
    /// <inheritdoc />
    public partial class CommandGroupNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "RoleName" },
                values: new object[] { "Command Group", "CommandGroup" });

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "RoleName" },
                values: new object[] { "Command Group Deputy", "CommandGroupDeputy" });

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "RoleName" },
                values: new object[] { "Command StaGroupff Assistant", "CommandGroupAssistant" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "RoleName" },
                values: new object[] { "Command Staff", "CommandStaff" });

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "RoleName" },
                values: new object[] { "Command Staff Deputy", "CommandStaffDeputy" });

            migrationBuilder.UpdateData(
                table: "PositionTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "RoleName" },
                values: new object[] { "Command Staff Assistant", "CommandStaffAssistant" });
        }
    }
}
