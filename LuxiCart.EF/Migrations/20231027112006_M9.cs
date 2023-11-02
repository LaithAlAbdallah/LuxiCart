using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuxiCart.EF.Migrations
{
    /// <inheritdoc />
    public partial class M9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColorImage",
                table: "productItems",
                newName: "Color");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Color",
                table: "productItems",
                newName: "ColorImage");
        }
    }
}
