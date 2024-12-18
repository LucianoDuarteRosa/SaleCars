using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleCars.Migrations
{
    /// <inheritdoc />
    public partial class AcertoTabelaCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarCodeFipe",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarCodeFipe",
                table: "cars");
        }
    }
}
