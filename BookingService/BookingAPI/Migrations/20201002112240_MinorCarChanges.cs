using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class MinorCarChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Convertable",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "NumberOfPassenger",
                table: "Cars");

            migrationBuilder.AddColumn<bool>(
                name: "Airconditioner",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Automatic",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPassengers",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airconditioner",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Automatic",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "NumberOfPassengers",
                table: "Cars");

            migrationBuilder.AddColumn<bool>(
                name: "Convertable",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPassenger",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
