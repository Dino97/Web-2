using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class CompanyImageConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LogoId",
                table: "RentalAgencies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RentalAgencies_LogoId",
                table: "RentalAgencies",
                column: "LogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalAgencies_Images_LogoId",
                table: "RentalAgencies",
                column: "LogoId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgencies_Images_LogoId",
                table: "RentalAgencies");

            migrationBuilder.DropIndex(
                name: "IX_RentalAgencies_LogoId",
                table: "RentalAgencies");

            migrationBuilder.AlterColumn<int>(
                name: "LogoId",
                table: "RentalAgencies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
