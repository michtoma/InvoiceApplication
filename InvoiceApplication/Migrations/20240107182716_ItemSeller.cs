using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApplication.Migrations
{
    /// <inheritdoc />
    public partial class ItemSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Item_SellerId",
                table: "Item",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Sellers_SellerId",
                table: "Item",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Sellers_SellerId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_SellerId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Item");
        }
    }
}
