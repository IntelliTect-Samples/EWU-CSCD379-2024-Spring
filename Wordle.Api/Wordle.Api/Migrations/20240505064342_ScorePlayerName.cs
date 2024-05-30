using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class ScorePlayerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Scores");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
