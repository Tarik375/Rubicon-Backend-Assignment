using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class AlterBlogPostTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTags_Slug",
                table: "BlogPostTags",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTags_TagId",
                table: "BlogPostTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTags_Blogs_Slug",
                table: "BlogPostTags",
                column: "Slug",
                principalTable: "Blogs",
                principalColumn: "Slug");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTags_Tags_TagId",
                table: "BlogPostTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTags_Blogs_Slug",
                table: "BlogPostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTags_Tags_TagId",
                table: "BlogPostTags");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostTags_Slug",
                table: "BlogPostTags");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostTags_TagId",
                table: "BlogPostTags");
        }
    }
}
