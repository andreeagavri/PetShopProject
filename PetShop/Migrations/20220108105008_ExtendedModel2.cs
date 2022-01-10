using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShop.Migrations
{
    public partial class ExtendedModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuppliedProduct_Publisher_SupplierID",
                table: "SuppliedProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher");

            migrationBuilder.RenameTable(
                name: "Publisher",
                newName: "Supplier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SuppliedProduct_Supplier_SupplierID",
                table: "SuppliedProduct",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuppliedProduct_Supplier_SupplierID",
                table: "SuppliedProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Publisher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SuppliedProduct_Publisher_SupplierID",
                table: "SuppliedProduct",
                column: "SupplierID",
                principalTable: "Publisher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
