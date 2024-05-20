using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeningGodtfolk.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForCategoryAndHistoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Historys");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Historys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Historys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Historys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Historys_CategoryId",
                table: "Historys",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Historys_Categories_CategoryId",
                table: "Historys",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historys_Categories_CategoryId",
                table: "Historys");

            migrationBuilder.DropIndex(
                name: "IX_Historys_CategoryId",
                table: "Historys");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Historys");

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Historys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Historys",
                keyColumn: "Id",
                keyValue: 1,
                column: "Theme",
                value: "Marked");

            migrationBuilder.UpdateData(
                table: "Historys",
                keyColumn: "Id",
                keyValue: 2,
                column: "Theme",
                value: "Marked");
        }
    }
}
