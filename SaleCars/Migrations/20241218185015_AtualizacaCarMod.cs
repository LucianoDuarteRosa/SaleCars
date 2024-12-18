using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleCars.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaCarMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarSale",
                table: "cars",
                newName: "CarSaleValue");

            migrationBuilder.AddColumn<bool>(
                name: "CarActive",
                table: "cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CarIsSale",
                table: "cars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarActive",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "CarIsSale",
                table: "cars");

            migrationBuilder.RenameColumn(
                name: "CarSaleValue",
                table: "cars",
                newName: "CarSale");
        }
    }
}
