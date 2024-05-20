using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeningGodtfolk.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoryTanleToDbAndSeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Historys",
                columns: new[] { "Id", "Date", "Description", "Theme", "Title" },
                values: new object[] { 2, new DateOnly(2024, 6, 27), "Vikinge markede Lindholm Høje. Marked med levende vikinger og salgsboder.", "Marked", "Lindholm Marked" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Historys",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
