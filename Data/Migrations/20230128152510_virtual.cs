using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Data.Migrations
{
    public partial class @virtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductTypesId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypesId",
                table: "Products",
                column: "ProductTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypesId",
                table: "Products",
                column: "ProductTypesId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypesId",
                table: "Products");
        }
    }
}
