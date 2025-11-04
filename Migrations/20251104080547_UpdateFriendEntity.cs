using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaPlatformBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFriendEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Relations",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "FollowerId",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "FollowingId",
                table: "Relations");

            migrationBuilder.RenameTable(
                name: "Relations",
                newName: "Friend");

            migrationBuilder.AddColumn<int>(
                name: "FollowerProfileId",
                table: "Friend",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FollowingProfileId",
                table: "Friend",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friend",
                table: "Friend",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_FollowerProfileId",
                table: "Friend",
                column: "FollowerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_FollowingProfileId",
                table: "Friend",
                column: "FollowingProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Profiles_FollowerProfileId",
                table: "Friend",
                column: "FollowerProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Profiles_FollowingProfileId",
                table: "Friend",
                column: "FollowingProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Profiles_FollowerProfileId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Profiles_FollowingProfileId",
                table: "Friend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friend",
                table: "Friend");

            migrationBuilder.DropIndex(
                name: "IX_Friend_FollowerProfileId",
                table: "Friend");

            migrationBuilder.DropIndex(
                name: "IX_Friend_FollowingProfileId",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "FollowerProfileId",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "FollowingProfileId",
                table: "Friend");

            migrationBuilder.RenameTable(
                name: "Friend",
                newName: "Relations");

            migrationBuilder.AddColumn<string>(
                name: "FollowerId",
                table: "Relations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FollowingId",
                table: "Relations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relations",
                table: "Relations",
                column: "Id");
        }
    }
}
