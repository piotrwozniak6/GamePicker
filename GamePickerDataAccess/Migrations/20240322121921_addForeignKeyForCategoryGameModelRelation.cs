using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamePickerWeb.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyForCategoryGameModelRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "GameModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "GameModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GameModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GameModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "GameModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "GameModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "GameModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "GameModels",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "GameModels",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoryId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_GameModels_CategoryId",
                table: "GameModels",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameModels_Categories_CategoryId",
                table: "GameModels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameModels_Categories_CategoryId",
                table: "GameModels");

            migrationBuilder.DropIndex(
                name: "IX_GameModels_CategoryId",
                table: "GameModels");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "GameModels");
        }
    }
}
