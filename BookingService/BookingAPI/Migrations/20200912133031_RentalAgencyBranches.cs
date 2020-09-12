using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class RentalAgencyBranches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalAgencies_Images_LogoId",
                table: "RentalAgencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalAgencies",
                table: "RentalAgencies");

            migrationBuilder.RenameTable(
                name: "RentalAgencies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_RentalAgencies_LogoId",
                table: "Company",
                newName: "IX_Company_LogoId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageLocation",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Company",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Company",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    PricePerDay = table.Column<float>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Convertable = table.Column<bool>(nullable: false),
                    NumberOfPassenger = table.Column<int>(nullable: false),
                    Drive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    Lat = table.Column<float>(nullable: false),
                    Lon = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalAgencyBranches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(nullable: false),
                    WorksFrom = table.Column<int>(nullable: false),
                    WorksTo = table.Column<int>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: true),
                    NearAirpot = table.Column<bool>(nullable: false),
                    RentalAgencyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalAgencyBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalAgencyBranches_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalAgencyBranches_Company_RentalAgencyId",
                        column: x => x.RentalAgencyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_Name",
                table: "Company",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalAgencyBranches_LocationId",
                table: "RentalAgencyBranches",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalAgencyBranches_RentalAgencyId",
                table: "RentalAgencyBranches",
                column: "RentalAgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Images_LogoId",
                table: "Company",
                column: "LogoId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Images_LogoId",
                table: "Company");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "RentalAgencyBranches");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_Name",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "RentalAgencies");

            migrationBuilder.RenameIndex(
                name: "IX_Company_LogoId",
                table: "RentalAgencies",
                newName: "IX_RentalAgencies_LogoId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageLocation",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RentalAgencies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

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
        }
    }
}
