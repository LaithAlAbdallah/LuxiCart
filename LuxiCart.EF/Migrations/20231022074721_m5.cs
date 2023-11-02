using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuxiCart.EF.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductParentCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductParentCategoryId",
                table: "Products",
                column: "ProductParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductParentCategory_ProductParentCategoryId",
                table: "Products",
                column: "ProductParentCategoryId",
                principalTable: "ProductParentCategory",
                principalColumn: "ProductParentCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductParentCategory_ProductParentCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductParentCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductParentCategoryId",
                table: "Products");
        }
    }
}
