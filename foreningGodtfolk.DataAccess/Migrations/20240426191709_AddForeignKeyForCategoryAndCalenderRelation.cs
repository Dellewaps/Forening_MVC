using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForeningGodtfolk.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForCategoryAndCalenderRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Calender");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Calender",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Calender",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Calender",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Calender_CategoryId",
                table: "Calender",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calender_Categories_CategoryId",
                table: "Calender",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calender_Categories_CategoryId",
                table: "Calender");

            migrationBuilder.DropIndex(
                name: "IX_Calender_CategoryId",
                table: "Calender");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Calender");

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Calender",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Calender",
                keyColumn: "Id",
                keyValue: 1,
                column: "Theme",
                value: "Marked");

            migrationBuilder.UpdateData(
                table: "Calender",
                keyColumn: "Id",
                keyValue: 2,
                column: "Theme",
                value: "Marked");
        }
    }
}
