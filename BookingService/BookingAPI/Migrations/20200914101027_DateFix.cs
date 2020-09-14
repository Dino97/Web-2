using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class DateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorksFrom",
                table: "RentalAgencyBranches");

            migrationBuilder.DropColumn(
                name: "WorksTo",
                table: "RentalAgencyBranches");

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkTimeFrom",
                table: "RentalAgencyBranches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkTimeTo",
                table: "RentalAgencyBranches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CarDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReserved = table.Column<DateTime>(nullable: false),
                    CarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDates_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDates_CarId",
                table: "CarDates",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDates");

            migrationBuilder.DropColumn(
                name: "WorkTimeFrom",
                table: "RentalAgencyBranches");

            migrationBuilder.DropColumn(
                name: "WorkTimeTo",
                table: "RentalAgencyBranches");

            migrationBuilder.AddColumn<int>(
                name: "WorksFrom",
                table: "RentalAgencyBranches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorksTo",
                table: "RentalAgencyBranches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
