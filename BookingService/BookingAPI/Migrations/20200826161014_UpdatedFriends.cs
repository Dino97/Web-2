using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.Migrations
{
    public partial class UpdatedFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId1",
                table: "UserFriends");

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_UserId1",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserFriends");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFriends",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FriendId",
                table: "UserFriends",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_UserId",
                table: "UserFriends",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends");

            migrationBuilder.DropIndex(
                name: "IX_UserFriends_UserId",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "UserFriends");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserFriends",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserFriends",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_UserId1",
                table: "UserFriends",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId1",
                table: "UserFriends",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
