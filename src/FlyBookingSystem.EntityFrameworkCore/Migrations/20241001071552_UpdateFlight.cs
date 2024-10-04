using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "flights");

            migrationBuilder.RenameColumn(
                name: "FlightNumber",
                table: "flights",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "Airline",
                table: "flights",
                newName: "From");

            migrationBuilder.RenameColumn(
                name: "AircraftModel",
                table: "flights",
                newName: "Duration");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalTime",
                table: "flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepratureTime",
                table: "flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "DepratureTime",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "flights");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "flights",
                newName: "FlightNumber");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "flights",
                newName: "Airline");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "flights",
                newName: "AircraftModel");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
