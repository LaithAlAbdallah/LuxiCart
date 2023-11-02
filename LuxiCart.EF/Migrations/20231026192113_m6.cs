using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuxiCart.EF.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productItems_productColors_ProductColorId",
                table: "productItems");

            migrationBuilder.DropForeignKey(
                name: "FK_productItems_productSizes_ProductSizeId",
                table: "productItems");

            migrationBuilder.DropTable(
                name: "productColors");

            migrationBuilder.DropTable(
                name: "productSizes");

            migrationBuilder.DropIndex(
                name: "IX_productItems_ProductColorId",
                table: "productItems");

            migrationBuilder.DropIndex(
                name: "IX_productItems_ProductSizeId",
                table: "productItems");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "productItems");

            migrationBuilder.DropColumn(
                name: "ProductSizeId",
                table: "productItems");

            migrationBuilder.RenameColumn(
                name: "ItemImage",
                table: "productItems",
                newName: "ColorImage");

            migrationBuilder.CreateTable(
                name: "productItemAttributes",
                columns: table => new
                {
                    ProductItemAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productItemAttributes", x => x.ProductItemAttributeId);
                    table.ForeignKey(
                        name: "FK_productItemAttributes_productItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "productItems",
                        principalColumn: "ProductItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productItemAttributes_ProductItemId",
                table: "productItemAttributes",
                column: "ProductItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productItemAttributes");

            migrationBuilder.RenameColumn(
                name: "ColorImage",
                table: "productItems",
                newName: "ItemImage");

            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "productItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductSizeId",
                table: "productItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "productColors",
                columns: table => new
                {
                    ProductColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productColors", x => x.ProductColorId);
                });

            migrationBuilder.CreateTable(
                name: "productSizes",
                columns: table => new
                {
                    ProductSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productSizes", x => x.ProductSizeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productItems_ProductColorId",
                table: "productItems",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_productItems_ProductSizeId",
                table: "productItems",
                column: "ProductSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_productItems_productColors_ProductColorId",
                table: "productItems",
                column: "ProductColorId",
                principalTable: "productColors",
                principalColumn: "ProductColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productItems_productSizes_ProductSizeId",
                table: "productItems",
                column: "ProductSizeId",
                principalTable: "productSizes",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
