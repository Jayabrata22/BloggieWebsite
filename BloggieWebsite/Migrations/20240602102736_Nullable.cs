using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloggieWebsite.Migrations
{
    /// <inheritdoc />
    public partial class Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "WebsiteMarkupProgress",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WebDesignProgress",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnePageProgress",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MobileTemplateProgress",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BackendAPIProgress",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WebsiteMarkupProgress",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WebDesignProgress",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnePageProgress",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MobileTemplateProgress",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BackendAPIProgress",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
