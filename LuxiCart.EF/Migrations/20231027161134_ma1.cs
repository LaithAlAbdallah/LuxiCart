using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuxiCart.EF.Migrations
{
    /// <inheritdoc />
    public partial class ma1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItemProductSize");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "productItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "productItems");

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    ProductSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sizes", x => x.ProductSizeId);
                });

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
    }
}
