using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleCars.Migrations
{
    /// <inheritdoc />
    public partial class TabelasAdicionaisCorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_supplier_ClientSupplierId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_ClientSupplierId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "ClientSupplierId",
                table: "cars");

            migrationBuilder.CreateIndex(
                name: "IX_cars_SupplierId",
                table: "cars",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_supplier_SupplierId",
                table: "cars",
                column: "SupplierId",
                principalTable: "supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_supplier_SupplierId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_SupplierId",
                table: "cars");

            migrationBuilder.AddColumn<int>(
                name: "ClientSupplierId",
                table: "cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cars_ClientSupplierId",
                table: "cars",
                column: "ClientSupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_supplier_ClientSupplierId",
                table: "cars",
                column: "ClientSupplierId",
                principalTable: "supplier",
                principalColumn: "SupplierId");
        }
    }
}
