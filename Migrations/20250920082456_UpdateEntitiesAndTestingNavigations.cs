using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialMediaPlatformBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesAndTestingNavigations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reactions",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "UsertId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ParenCommnedId",
                table: "Comments",
                newName: "ParenCommentId");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Reactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Reactions");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Reactions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "UsertId");

            migrationBuilder.RenameColumn(
                name: "ParenCommentId",
                table: "Comments",
                newName: "ParenCommnedId");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "Bio", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "LastLogin", "LastName", "PasswordHash", "ProfilePicture", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, "Just a regular John Doe.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John@google.com", "John", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", "hashed_password_123", "https://pbs.twimg.com/profile_images/1938321133884813312/BU8hdbr__400x400.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john_doe" },
                    { 2, "Just a regular John Doe.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John@google.com", "John", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", "hashed_password_123", "https://pbs.twimg.com/profile_images/1938321133884813312/BU8hdbr__400x400.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john_doe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "CommentsCount", "Content", "CreatedAt", "ImageUrl", "IsActive", "LikesCount", "ProfileId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 0, "Hello, world! This is my first post.", new DateTime(2025, 8, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/posts/first_post.jpg", true, 0, 1, new DateTime(2025, 8, 29, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Just had a great day at the park!", new DateTime(2025, 8, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "https://example.com/posts/park_day.jpg", true, 5, 2, new DateTime(2025, 8, 30, 15, 30, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
