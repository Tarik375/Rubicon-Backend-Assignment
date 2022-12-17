using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class CommentMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Comments_CommentId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CommentId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "BlogPostSlug",
                table: "Comments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogPostSlug",
                table: "Comments",
                column: "BlogPostSlug",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogPostSlug",
                table: "Comments",
                column: "BlogPostSlug",
                principalTable: "Blogs",
                principalColumn: "Slug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogPostSlug",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogPostSlug",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogPostSlug",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Blogs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CommentId",
                table: "Blogs",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Comments_CommentId",
                table: "Blogs",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
