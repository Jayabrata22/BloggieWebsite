using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloggieWebsite.Migrations
{
    /// <inheritdoc />
    public partial class Userdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "PostComments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "BlogPosts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "BlogPostLike",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Github = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebDesignProgress = table.Column<int>(type: "int", nullable: false),
                    WebsiteMarkupProgress = table.Column<int>(type: "int", nullable: false),
                    OnePageProgress = table.Column<int>(type: "int", nullable: false),
                    MobileTemplateProgress = table.Column<int>(type: "int", nullable: false),
                    BackendAPIProgress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UsersId",
                table: "Tags",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_UsersId",
                table: "PostComments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UsersId",
                table: "BlogPosts",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostLike_UsersId",
                table: "BlogPostLike",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostLike_Users_UsersId",
                table: "BlogPostLike",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_UsersId",
                table: "BlogPosts",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Users_UsersId",
                table: "PostComments",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_UsersId",
                table: "Tags",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostLike_Users_UsersId",
                table: "BlogPostLike");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_UsersId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Users_UsersId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_UsersId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tags_UsersId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_UsersId",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_UsersId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostLike_UsersId",
                table: "BlogPostLike");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "BlogPostLike");
        }
    }
}
