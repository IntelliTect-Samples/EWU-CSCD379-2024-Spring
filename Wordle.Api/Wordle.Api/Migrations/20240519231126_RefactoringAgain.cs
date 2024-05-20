using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_WordOfTheDay_WordOfTheDayId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Words_WordId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "WordOfTheDayId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WordId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_WordOfTheDay_WordOfTheDayId",
                table: "Games",
                column: "WordOfTheDayId",
                principalTable: "WordOfTheDay",
                principalColumn: "WordOfTheDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Words_WordId",
                table: "Games",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_WordOfTheDay_WordOfTheDayId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Words_WordId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "WordOfTheDayId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WordId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_WordOfTheDay_WordOfTheDayId",
                table: "Games",
                column: "WordOfTheDayId",
                principalTable: "WordOfTheDay",
                principalColumn: "WordOfTheDayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Words_WordId",
                table: "Games",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId");
        }
    }
}
