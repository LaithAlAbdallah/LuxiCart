using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuxiCart.EF.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productItems_sizes_ProductSizeId",
                table: "productItems");

            migrationBuilder.DropIndex(
                name: "IX_productItems_ProductSizeId",
                table: "productItems");

            migrationBuilder.DropColumn(
                name: "ProductSizeId",
                table: "productItems");

            migrationBuilder.CreateTable(
                name: "ProductItemProductSize",
                columns: table => new
                {
                    productItemsProductItemId = table.Column<int>(type: "int", nullable: false),
                    productSizesProductSizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemProductSize", x => new { x.productItemsProductItemId, x.productSizesProductSizeId });
                    table.ForeignKey(
                        name: "FK_ProductItemProductSize_productItems_productItemsProductItemId",
                        column: x => x.productItemsProductItemId,
                        principalTable: "productItems",
                        principalColumn: "ProductItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItemProductSize_sizes_productSizesProductSizeId",
                        column: x => x.productSizesProductSizeId,
                        principalTable: "sizes",
                        principalColumn: "ProductSizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItemProductSize_productSizesProductSizeId",
                table: "ProductItemProductSize",
                column: "productSizesProductSizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItemProductSize");

            migrationBuilder.AddColumn<int>(
                name: "ProductSizeId",
                table: "productItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_productItems_ProductSizeId",
                table: "productItems",
                column: "ProductSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_productItems_sizes_ProductSizeId",
                table: "productItems",
                column: "ProductSizeId",
                principalTable: "sizes",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
