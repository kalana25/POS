using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DAL.Migrations
{
    public partial class AddItemToPurchaseUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "PurchaseUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseUnits_ItemId",
                table: "PurchaseUnits",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseUnits_Items_ItemId",
                table: "PurchaseUnits",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseUnits_Items_ItemId",
                table: "PurchaseUnits");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseUnits_ItemId",
                table: "PurchaseUnits");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "PurchaseUnits");
        }
    }
}
