using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsVendor.Migrations
{
    public partial class ModelLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelLineId",
                table: "ComponentVendors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ModelLines",
                columns: table => new
                {
                    ModelLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelLines", x => x.ModelLineId);
                    table.ForeignKey(
                        name: "FK_ModelLines_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentVendors_ModelLineId",
                table: "ComponentVendors",
                column: "ModelLineId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelLines_ComponentId",
                table: "ModelLines",
                column: "ComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentVendors_ModelLines_ModelLineId",
                table: "ComponentVendors",
                column: "ModelLineId",
                principalTable: "ModelLines",
                principalColumn: "ModelLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentVendors_ModelLines_ModelLineId",
                table: "ComponentVendors");

            migrationBuilder.DropTable(
                name: "ModelLines");

            migrationBuilder.DropIndex(
                name: "IX_ComponentVendors_ModelLineId",
                table: "ComponentVendors");

            migrationBuilder.DropColumn(
                name: "ModelLineId",
                table: "ComponentVendors");
        }
    }
}
