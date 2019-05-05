using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Memo.Api.Migrations
{
    public partial class settersInWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordStatistics_Words_WordId",
                table: "WordStatistics");

            migrationBuilder.DropIndex(
                name: "IX_WordStatistics_WordId",
                table: "WordStatistics");

            migrationBuilder.AlterColumn<Guid>(
                name: "WordId",
                table: "WordStatistics",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Words",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Words",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordStatistics_WordId",
                table: "WordStatistics",
                column: "WordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WordStatistics_Words_WordId",
                table: "WordStatistics",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordStatistics_Words_WordId",
                table: "WordStatistics");

            migrationBuilder.DropIndex(
                name: "IX_WordStatistics_WordId",
                table: "WordStatistics");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Words");

            migrationBuilder.AlterColumn<Guid>(
                name: "WordId",
                table: "WordStatistics",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_WordStatistics_WordId",
                table: "WordStatistics",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordStatistics_Words_WordId",
                table: "WordStatistics",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
