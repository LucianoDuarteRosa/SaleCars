using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleCars.Migrations
{
    /// <inheritdoc />
    public partial class TabelasAdicionais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientPhone",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "sale_status",
                columns: table => new
                {
                    SaleStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleStatusName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale_status", x => x.SaleStatusId);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SupplierCpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierAdress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SupplierPixType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SupplierPixKey = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupplierNote = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupplierActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CarMark = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CarYear = table.Column<int>(type: "int", nullable: false),
                    CarPlate = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    CarTableFipe = table.Column<double>(type: "float", nullable: false),
                    CarValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarDateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    ClientSupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_cars_supplier_ClientSupplierId",
                        column: x => x.ClientSupplierId,
                        principalTable: "supplier",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleStatusId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StatusSaleStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_sales_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_cars_CarId",
                        column: x => x.CarId,
                        principalTable: "cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_sale_status_StatusSaleStatusId",
                        column: x => x.StatusSaleStatusId,
                        principalTable: "sale_status",
                        principalColumn: "SaleStatusId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_ClientSupplierId",
                table: "cars",
                column: "ClientSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_CarId",
                table: "sales",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_ClientId",
                table: "sales",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_StatusSaleStatusId",
                table: "sales",
                column: "StatusSaleStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_UserID",
                table: "sales",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "sale_status");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropColumn(
                name: "ClientPhone",
                table: "clients");
        }
    }
}
