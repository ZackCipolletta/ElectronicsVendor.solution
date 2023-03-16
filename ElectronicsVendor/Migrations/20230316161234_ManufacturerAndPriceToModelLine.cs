using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsVendor.Migrations
{
    public partial class ManufacturerAndPriceToModelLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "ModelLines",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ModelLines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "ModelLines");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ModelLines");
        }
    }
}
