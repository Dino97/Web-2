using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDates_Cars_CarId",
                table: "CarDates");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgencyBranches_Company_RentalAgencyId",
                table: "RentalAgencyBranches");

            migrationBuilder.AlterColumn<int>(
                name: "RentalAgencyId",
                table: "RentalAgencyBranches",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentalAgencyBranchId",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "CarDates",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentalAgencyBranchId",
                table: "Cars",
                column: "RentalAgencyBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDates_Cars_CarId",
                table: "CarDates",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_RentalAgencyBranches_RentalAgencyBranchId",
                table: "Cars",
                column: "RentalAgencyBranchId",
                principalTable: "RentalAgencyBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalAgencyBranches_Company_RentalAgencyId",
                table: "RentalAgencyBranches",
                column: "RentalAgencyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDates_Cars_CarId",
                table: "CarDates");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_RentalAgencyBranches_RentalAgencyBranchId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgencyBranches_Company_RentalAgencyId",
                table: "RentalAgencyBranches");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RentalAgencyBranchId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RentalAgencyBranchId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "RentalAgencyId",
                table: "RentalAgencyBranches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "CarDates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CarDates_Cars_CarId",
                table: "CarDates",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalAgencyBranches_Company_RentalAgencyId",
                table: "RentalAgencyBranches",
                column: "RentalAgencyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
