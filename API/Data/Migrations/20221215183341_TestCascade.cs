using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class TestCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTags_Blogs_Slug",
                table: "BlogPostTags");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "BlogPostTags",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTags_Blogs_Slug",
                table: "BlogPostTags",
                column: "Slug",
                principalTable: "Blogs",
                principalColumn: "Slug",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTags_Blogs_Slug",
                table: "BlogPostTags");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "BlogPostTags",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTags_Blogs_Slug",
                table: "BlogPostTags",
                column: "Slug",
                principalTable: "Blogs",
                principalColumn: "Slug");
        }
    }
}
