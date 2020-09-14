using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class RentalAgencyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Images_LogoId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgencyBranches_Company_RentalAgencyId",
                table: "RentalAgencyBranches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "RentalAgencies");

            migrationBuilder.RenameIndex(
                name: "IX_Company_Name",
                table: "RentalAgencies",
                newName: "IX_RentalAgencies_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Company_LogoId",
                table: "RentalAgencies",
                newName: "IX_RentalAgencies_LogoId");

            migrationBuilder.AlterColumn<int>(
                name: "RentalAgencyId",
                table: "RentalAgencyBranches",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "RentalAgencyBranches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AdminUserName",
                table: "RentalAgencies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalAgencies",
                table: "RentalAgencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalAgencies_Images_LogoId",
                table: "RentalAgencies",
                column: "LogoId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalAgencyBranches_RentalAgencies_RentalAgencyId",
                table: "RentalAgencyBranches",
                column: "RentalAgencyId",
                principalTable: "RentalAgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgencies_Images_LogoId",
                table: "RentalAgencies");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgencyBranches_RentalAgencies_RentalAgencyId",
                table: "RentalAgencyBranches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalAgencies",
                table: "RentalAgencies");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "RentalAgencyBranches");

            migrationBuilder.RenameTable(
                name: "RentalAgencies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_RentalAgencies_Name",
                table: "Company",
                newName: "IX_Company_Name");

            migrationBuilder.RenameIndex(
                name: "IX_RentalAgencies_LogoId",
                table: "Company",
                newName: "IX_Company_LogoId");

            migrationBuilder.AlterColumn<int>(
                name: "RentalAgencyId",
                table: "RentalAgencyBranches",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminUserName",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Images_LogoId",
                table: "Company",
                column: "LogoId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalAgencyBranches_Company_RentalAgencyId",
                table: "RentalAgencyBranches",
                column: "RentalAgencyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
