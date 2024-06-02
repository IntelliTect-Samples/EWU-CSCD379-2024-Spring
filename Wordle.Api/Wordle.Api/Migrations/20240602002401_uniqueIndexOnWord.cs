using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class uniqueIndexOnWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Words_Text",
                table: "Words");

            migrationBuilder.CreateIndex(
                name: "IX_Words_Text",
                table: "Words",
                column: "Text",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Words_Text",
                table: "Words");

            migrationBuilder.CreateIndex(
                name: "IX_Words_Text",
                table: "Words",
                column: "Text");
        }
    }
}
