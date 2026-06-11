using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTripTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TripDate",
                table: "Trips",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RegisteredVehicleId",
                table: "Trips",
                column: "RegisteredVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_VehicleId",
                table: "Trips",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_RegisteredVehicles_RegisteredVehicleId",
                table: "Trips",
                column: "RegisteredVehicleId",
                principalTable: "RegisteredVehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Vehicles_VehicleId",
                table: "Trips",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_RegisteredVehicles_RegisteredVehicleId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Vehicles_VehicleId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_RegisteredVehicleId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_VehicleId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TripDate",
                table: "Trips");
        }
    }
}
