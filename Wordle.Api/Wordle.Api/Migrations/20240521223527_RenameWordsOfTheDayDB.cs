using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameWordsOfTheDayDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_WordOfTheDay_WordOfTheDayId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_WordOfTheDay_Words_WordId",
                table: "WordOfTheDay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordOfTheDay",
                table: "WordOfTheDay");

            migrationBuilder.RenameTable(
                name: "WordOfTheDay",
                newName: "WordsOfTheDays");

            migrationBuilder.RenameIndex(
                name: "IX_WordOfTheDay_WordId",
                table: "WordsOfTheDays",
                newName: "IX_WordsOfTheDays_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordsOfTheDays",
                table: "WordsOfTheDays",
                column: "WordOfTheDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_WordsOfTheDays_WordOfTheDayId",
                table: "Games",
                column: "WordOfTheDayId",
                principalTable: "WordsOfTheDays",
                principalColumn: "WordOfTheDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordsOfTheDays_Words_WordId",
                table: "WordsOfTheDays",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_WordsOfTheDays_WordOfTheDayId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_WordsOfTheDays_Words_WordId",
                table: "WordsOfTheDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordsOfTheDays",
                table: "WordsOfTheDays");

            migrationBuilder.RenameTable(
                name: "WordsOfTheDays",
                newName: "WordOfTheDay");

            migrationBuilder.RenameIndex(
                name: "IX_WordsOfTheDays_WordId",
                table: "WordOfTheDay",
                newName: "IX_WordOfTheDay_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordOfTheDay",
                table: "WordOfTheDay",
                column: "WordOfTheDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_WordOfTheDay_WordOfTheDayId",
                table: "Games",
                column: "WordOfTheDayId",
                principalTable: "WordOfTheDay",
                principalColumn: "WordOfTheDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordOfTheDay_Words_WordId",
                table: "WordOfTheDay",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
