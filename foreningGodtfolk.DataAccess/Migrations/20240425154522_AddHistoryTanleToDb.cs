using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeningGodtfolk.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoryTanleToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historys", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Historys",
                columns: new[] { "Id", "Date", "Description", "Theme", "Title" },
                values: new object[] { 1, new DateOnly(2024, 5, 8), "Markedet hvor der vises håndværk fra gammle tider og sælges ting", "Marked", "Tylstrup Middelalder Marked" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historys");
        }
    }
}
