using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStatusToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "RegisteredVehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "RegisteredVehicles");
        }
    }
}
