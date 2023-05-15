using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliciousPieShop.Migrations
{
    public partial class setShoppingcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShppongCartId",
                table: "ShoppingCartItems",
                newName: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShoppingCartItems",
                newName: "ShppongCartId");
        }
    }
}
