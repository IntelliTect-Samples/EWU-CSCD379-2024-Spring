using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class WordOfTheDayGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WordOfTheDayGames",
                columns: table => new
                {
                    WordOfTheDayGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    IsWin = table.Column<bool>(type: "bit", nullable: false),
                    DateAttempted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WordOfTheDayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordOfTheDayGames", x => x.WordOfTheDayGameId);
                    table.ForeignKey(
                        name: "FK_WordOfTheDayGames_WordOfTheDay_WordOfTheDayId",
                        column: x => x.WordOfTheDayId,
                        principalTable: "WordOfTheDay",
                        principalColumn: "WordOfTheDayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordOfTheDayGames_WordOfTheDayId",
                table: "WordOfTheDayGames",
                column: "WordOfTheDayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordOfTheDayGames");
        }
    }
}
