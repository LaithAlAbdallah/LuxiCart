using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuxiCart.EF.Migrations
{
    /// <inheritdoc />
    public partial class m7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productItemAttributes");

            migrationBuilder.AddColumn<string>(
                name: "ItemImage",
                table: "productItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductSizeId",
                table: "productItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productItems_sizes_ProductSizeId",
                table: "productItems");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropIndex(
                name: "IX_productItems_ProductSizeId",
                table: "productItems");

            migrationBuilder.DropColumn(
                name: "ItemImage",
                table: "productItems");

            migrationBuilder.DropColumn(
                name: "ProductSizeId",
                table: "productItems");

            migrationBuilder.CreateTable(
                name: "productItemAttributes",
                columns: table => new
                {
                    ProductItemAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
