using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuxiCart.EF.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductParentCategory",
                columns: table => new
                {
                    ProductParentCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductParentCategory", x => x.ProductParentCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryProductParentCategory",
                columns: table => new
                {
                    productCategoriesProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    productParentCategoriesProductParentCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryProductParentCategory", x => new { x.productCategoriesProductCategoryId, x.productParentCategoriesProductParentCategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategoryProductParentCategory_ProductCategories_productCategoriesProductCategoryId",
                        column: x => x.productCategoriesProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryProductParentCategory_ProductParentCategory_productParentCategoriesProductParentCategoryId",
                        column: x => x.productParentCategoriesProductParentCategoryId,
                        principalTable: "ProductParentCategory",
                        principalColumn: "ProductParentCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryProductParentCategory_productParentCategoriesProductParentCategoryId",
                table: "ProductCategoryProductParentCategory",
                column: "productParentCategoriesProductParentCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategoryProductParentCategory");

            migrationBuilder.DropTable(
                name: "ProductParentCategory");
        }
    }
}
