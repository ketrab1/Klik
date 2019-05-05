using Microsoft.EntityFrameworkCore.Migrations;

namespace Memo.Api.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyWord",
                table: "WordStatistics");

            migrationBuilder.AddColumn<int>(
                name: "DifficultyWord",
                table: "Words",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyWord",
                table: "Words");

            migrationBuilder.AddColumn<int>(
                name: "DifficultyWord",
                table: "WordStatistics",
                nullable: false,
                defaultValue: 0);
        }
    }
}
