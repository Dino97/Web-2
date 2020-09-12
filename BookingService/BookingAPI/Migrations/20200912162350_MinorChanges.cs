using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class MinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "AdminUserName",
                table: "Company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminUserName",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
