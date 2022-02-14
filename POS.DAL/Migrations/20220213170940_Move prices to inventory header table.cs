using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.DAL.Migrations
{
    public partial class Movepricestoinventoryheadertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasingPricePerBaseUnit",
                table: "InventoryDetails");

            migrationBuilder.DropColumn(
                name: "SellingPricePerBaseUnit",
                table: "InventoryDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasingPricePerBaseUnit",
                table: "Inventories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SellingPricePerBaseUnit",
                table: "Inventories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasingPricePerBaseUnit",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "SellingPricePerBaseUnit",
                table: "Inventories");

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasingPricePerBaseUnit",
                table: "InventoryDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SellingPricePerBaseUnit",
                table: "InventoryDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
