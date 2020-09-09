using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class ImageTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageData",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
