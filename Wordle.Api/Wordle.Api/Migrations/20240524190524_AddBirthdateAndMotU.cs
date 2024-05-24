using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthdateAndMotU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthdate",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "IsMasterOfTheUniverse",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsMasterOfTheUniverse",
                table: "AspNetUsers");
        }
    }
}
