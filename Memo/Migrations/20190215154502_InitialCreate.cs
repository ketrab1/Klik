using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Memo.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NextIteration = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumberTypedCorrect = table.Column<int>(nullable: false),
                    TimesTypedWrong = table.Column<int>(nullable: false),
                    TimesLoaded = table.Column<int>(nullable: false),
                    DifficultyWord = table.Column<int>(nullable: false),
                    WordId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordStatistics_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordStatistics_WordId",
                table: "WordStatistics",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordStatistics");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
