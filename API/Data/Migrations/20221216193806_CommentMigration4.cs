using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class CommentMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogPostSlug",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogPostSlug",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BlogPostSlug",
                table: "Comments",
                newName: "blogPostSlug");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_blogPostSlug",
                table: "Comments",
                column: "blogPostSlug");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_blogPostSlug",
                table: "Comments",
                column: "blogPostSlug",
                principalTable: "Blogs",
                principalColumn: "Slug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_blogPostSlug",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_blogPostSlug",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "blogPostSlug",
                table: "Comments",
                newName: "BlogPostSlug");

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
    }
}
