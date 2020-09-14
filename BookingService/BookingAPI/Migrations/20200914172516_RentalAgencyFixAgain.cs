using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class RentalAgencyFixAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgencyBranches_RentalAgencies_RentalAgencyId",
                table: "RentalAgencyBranches");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "RentalAgencyBranches");

            migrationBuilder.AlterColumn<int>(
                name: "RentalAgencyId",
                table: "RentalAgencyBranches",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalAgencyBranches_RentalAgencies_RentalAgencyId",
                table: "RentalAgencyBranches",
                column: "RentalAgencyId",
                principalTable: "RentalAgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgencyBranches_RentalAgencies_RentalAgencyId",
                table: "RentalAgencyBranches");

            migrationBuilder.AlterColumn<int>(
                name: "RentalAgencyId",
                table: "RentalAgencyBranches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "RentalAgencyBranches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalAgencyBranches_RentalAgencies_RentalAgencyId",
                table: "RentalAgencyBranches",
                column: "RentalAgencyId",
                principalTable: "RentalAgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
