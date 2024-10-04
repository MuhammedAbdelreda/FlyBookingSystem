using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlyBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepratureTime",
                table: "flights",
                newName: "DepartureTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "flights",
                newName: "DepratureTime");
        }
    }
}
