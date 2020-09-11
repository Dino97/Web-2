using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class FlightDestinations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airports_Flights_FlightId",
                table: "Airports");

            migrationBuilder.DropIndex(
                name: "IX_Airports_FlightId",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Airports");

            migrationBuilder.AddColumn<string>(
                name: "Locations",
                table: "Flights",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locations",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Airports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airports_FlightId",
                table: "Airports",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_Flights_FlightId",
                table: "Airports",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
