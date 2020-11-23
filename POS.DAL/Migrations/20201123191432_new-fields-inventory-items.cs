using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DAL.Migrations
{
    public partial class newfieldsinventoryitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpenBalanceQuantity",
                table: "InventoryDetails",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenBalanceQuantity",
                table: "InventoryDetails");

            migrationBuilder.DropColumn(
                name: "PurchasingPricePerBaseUnit",
                table: "InventoryDetails");

            migrationBuilder.DropColumn(
                name: "SellingPricePerBaseUnit",
                table: "InventoryDetails");
        }
    }
}
