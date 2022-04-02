using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuretaNeko.Infrastructure.Migrations
{
    public partial class SkillExp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "public",
                table: "Skills",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OptionKey",
                schema: "public",
                table: "Skills",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "public",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "OptionKey",
                schema: "public",
                table: "Skills");
        }
    }
}
