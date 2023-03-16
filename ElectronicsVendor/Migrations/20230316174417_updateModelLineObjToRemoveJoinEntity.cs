using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicsVendor.Migrations
{
    public partial class updateModelLineObjToRemoveJoinEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentVendors_ModelLines_ModelLineId",
                table: "ComponentVendors");

            migrationBuilder.DropIndex(
                name: "IX_ComponentVendors_ModelLineId",
                table: "ComponentVendors");

            migrationBuilder.DropColumn(
                name: "ModelLineId",
                table: "ComponentVendors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelLineId",
                table: "ComponentVendors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentVendors_ModelLineId",
                table: "ComponentVendors",
                column: "ModelLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentVendors_ModelLines_ModelLineId",
                table: "ComponentVendors",
                column: "ModelLineId",
                principalTable: "ModelLines",
                principalColumn: "ModelLineId");
        }
    }
}
