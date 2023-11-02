using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuxiCart.EF.Migrations
{
    /// <inheritdoc />
    public partial class ma4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryProductParentCategory_ProductCategories_productCategoriesProductCategoryId",
                table: "ProductCategoryProductParentCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryProductParentCategory_ProductParentCategory_productParentCategoriesProductParentCategoryId",
                table: "ProductCategoryProductParentCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryPromotion_ProductCategories_ProductCategoryId",
                table: "ProductCategoryPromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductParentCategory_ProductParentCategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductParentCategory",
                table: "ProductParentCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "ProductParentCategory",
                newName: "productParentCategories");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductSubCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productParentCategories",
                table: "productParentCategories",
                column: "ProductParentCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSubCategories",
                table: "ProductSubCategories",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryProductParentCategory_ProductSubCategories_productCategoriesProductCategoryId",
                table: "ProductCategoryProductParentCategory",
                column: "productCategoriesProductCategoryId",
                principalTable: "ProductSubCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryProductParentCategory_productParentCategories_productParentCategoriesProductParentCategoryId",
                table: "ProductCategoryProductParentCategory",
                column: "productParentCategoriesProductParentCategoryId",
                principalTable: "productParentCategories",
                principalColumn: "ProductParentCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryPromotion_ProductSubCategories_ProductCategoryId",
                table: "ProductCategoryPromotion",
                column: "ProductCategoryId",
                principalTable: "ProductSubCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSubCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductSubCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_productParentCategories_ProductParentCategoryId",
                table: "Products",
                column: "ProductParentCategoryId",
                principalTable: "productParentCategories",
                principalColumn: "ProductParentCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryProductParentCategory_ProductSubCategories_productCategoriesProductCategoryId",
                table: "ProductCategoryProductParentCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryProductParentCategory_productParentCategories_productParentCategoriesProductParentCategoryId",
                table: "ProductCategoryProductParentCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryPromotion_ProductSubCategories_ProductCategoryId",
                table: "ProductCategoryPromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSubCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_productParentCategories_ProductParentCategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSubCategories",
                table: "ProductSubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productParentCategories",
                table: "productParentCategories");

            migrationBuilder.RenameTable(
                name: "ProductSubCategories",
                newName: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "productParentCategories",
                newName: "ProductParentCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "ProductCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductParentCategory",
                table: "ProductParentCategory",
                column: "ProductParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryProductParentCategory_ProductCategories_productCategoriesProductCategoryId",
                table: "ProductCategoryProductParentCategory",
                column: "productCategoriesProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryProductParentCategory_ProductParentCategory_productParentCategoriesProductParentCategoryId",
                table: "ProductCategoryProductParentCategory",
                column: "productParentCategoriesProductParentCategoryId",
                principalTable: "ProductParentCategory",
                principalColumn: "ProductParentCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryPromotion_ProductCategories_ProductCategoryId",
                table: "ProductCategoryPromotion",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductParentCategory_ProductParentCategoryId",
                table: "Products",
                column: "ProductParentCategoryId",
                principalTable: "ProductParentCategory",
                principalColumn: "ProductParentCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
