using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GameCount = table.Column<int>(type: "int", nullable: false),
                    AverageAttempts = table.Column<double>(type: "float", nullable: false),
                    AverageSecondsPerGame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

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

            migrationBuilder.DropTable(
                name: "Players");

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
