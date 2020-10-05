using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class CarReservationsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReservations_Locations_DropoffLocationId",
                table: "CarReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_CarReservations_Locations_PickupLocationId",
                table: "CarReservations");

            migrationBuilder.DropIndex(
                name: "IX_CarReservations_DropoffLocationId",
                table: "CarReservations");

            migrationBuilder.DropIndex(
                name: "IX_CarReservations_PickupLocationId",
                table: "CarReservations");

            migrationBuilder.AlterColumn<int>(
                name: "PickupLocationId",
                table: "CarReservations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DropoffLocationId",
                table: "CarReservations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PickupLocationId",
                table: "CarReservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DropoffLocationId",
                table: "CarReservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_CarReservations_DropoffLocationId",
                table: "CarReservations",
                column: "DropoffLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarReservations_PickupLocationId",
                table: "CarReservations",
                column: "PickupLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReservations_Locations_DropoffLocationId",
                table: "CarReservations",
                column: "DropoffLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarReservations_Locations_PickupLocationId",
                table: "CarReservations",
                column: "PickupLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
