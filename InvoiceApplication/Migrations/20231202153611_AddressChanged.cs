using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddressChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressCompany");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CompanyId",
                table: "Addresses",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Company_CompanyId",
                table: "Addresses",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Company_CompanyId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CompanyId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Addresses");

            migrationBuilder.CreateTable(
                name: "AddressCompany",
                columns: table => new
                {
                    AddressesId = table.Column<int>(type: "int", nullable: false),
                    CompaniesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCompany", x => new { x.AddressesId, x.CompaniesId });
                    table.ForeignKey(
                        name: "FK_AddressCompany_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressCompany_Company_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressCompany_CompaniesId",
                table: "AddressCompany",
                column: "CompaniesId");
        }
    }
}
