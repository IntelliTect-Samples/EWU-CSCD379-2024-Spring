using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class RestructureDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM WordOfTheDay");

            migrationBuilder.DropTable(
                name: "WordOfTheDayGames");

            migrationBuilder.DropColumn(
                name: "Word",
                table: "WordOfTheDay");

            migrationBuilder.AddColumn<int>(
                name: "WordId",
                table: "WordOfTheDay",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    IsWin = table.Column<bool>(type: "bit", nullable: false),
                    DateAttempted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WordOfTheDayId = table.Column<int>(type: "int", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_WordOfTheDay_WordOfTheDayId",
                        column: x => x.WordOfTheDayId,
                        principalTable: "WordOfTheDay",
                        principalColumn: "WordOfTheDayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordOfTheDay_WordId",
                table: "WordOfTheDay",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WordId",
                table: "Games",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WordOfTheDayId",
                table: "Games",
                column: "WordOfTheDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordOfTheDay_Words_WordId",
                table: "WordOfTheDay",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordOfTheDay_Words_WordId",
                table: "WordOfTheDay");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropIndex(
                name: "IX_WordOfTheDay_WordId",
                table: "WordOfTheDay");

            migrationBuilder.DropColumn(
                name: "WordId",
                table: "WordOfTheDay");

            migrationBuilder.AddColumn<string>(
                name: "Word",
                table: "WordOfTheDay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "WordOfTheDayGames",
                columns: table => new
                {
                    WordOfTheDayGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordOfTheDayId = table.Column<int>(type: "int", nullable: false),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    DateAttempted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsWin = table.Column<bool>(type: "bit", nullable: false)
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
    }
}
