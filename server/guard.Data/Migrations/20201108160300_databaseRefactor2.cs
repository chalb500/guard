using Microsoft.EntityFrameworkCore.Migrations;

namespace guard.Data.Migrations
{
    public partial class databaseRefactor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserProfiles");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileProfileId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserProfileProfileId",
                table: "Users",
                column: "UserProfileProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserProfiles_UserProfileProfileId",
                table: "Users",
                column: "UserProfileProfileId",
                principalTable: "UserProfiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserProfiles_UserProfileProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserProfileProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserProfileProfileId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
