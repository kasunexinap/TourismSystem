using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToRegisteredVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RegisteredVehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "RegisteredVehicles");
        }
    }
}
