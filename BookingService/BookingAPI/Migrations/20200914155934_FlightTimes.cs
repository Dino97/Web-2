using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class FlightTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AirlineName",
                table: "Flights",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlineName",
                table: "Flights",
                column: "AirlineName");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airlines_AirlineName",
                table: "Flights",
                column: "AirlineName",
                principalTable: "Airlines",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airlines_AirlineName",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirlineName",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirlineName",
                table: "Flights");
        }
    }
}
