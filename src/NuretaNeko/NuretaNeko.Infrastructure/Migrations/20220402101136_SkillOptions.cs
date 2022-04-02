using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuretaNeko.Infrastructure.Migrations
{
    public partial class SkillOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionKey",
                schema: "public",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Score",
                schema: "public",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Value",
                schema: "public",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "SkillOptions",
                schema: "public",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionKey = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillOptions", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_SkillOptions_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "public",
                        principalTable: "Skills",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillOptions_SkillId",
                schema: "public",
                table: "SkillOptions",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillOptions",
                schema: "public");

            migrationBuilder.AddColumn<string>(
                name: "OptionKey",
                schema: "public",
                table: "Skills",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                schema: "public",
                table: "Skills",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                schema: "public",
                table: "Skills",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
