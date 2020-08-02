using Microsoft.EntityFrameworkCore.Migrations;

namespace Evlog.Infrastructure.Data.Migrations.MySqlMigrations
{
    public partial class SeparateFieldsForBodyMarkdownAndHtml : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "EventPosts");

            migrationBuilder.AddColumn<string>(
                name: "BodyHtml",
                table: "EventPosts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyMarkdown",
                table: "EventPosts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyHtml",
                table: "EventPosts");

            migrationBuilder.DropColumn(
                name: "BodyMarkdown",
                table: "EventPosts");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "EventPosts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
