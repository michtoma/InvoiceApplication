using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddressChanged2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerAddressId",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerAddressId",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_BuyerAddressId",
                table: "Invoice",
                column: "BuyerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SellerAddressId",
                table: "Invoice",
                column: "SellerAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Addresses_BuyerAddressId",
                table: "Invoice",
                column: "BuyerAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Addresses_SellerAddressId",
                table: "Invoice",
                column: "SellerAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Addresses_BuyerAddressId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Addresses_SellerAddressId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_BuyerAddressId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_SellerAddressId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "BuyerAddressId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "SellerAddressId",
                table: "Invoice");
        }
    }
}
