using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DAL.Migrations
{
    public partial class model_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Units_BaseUnitId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Items_ItemId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDetail_GoodReceivedNotes_GrnId",
                table: "InventoryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDetail_Inventory_InventoryId",
                table: "InventoryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDetail_Units_UnitId",
                table: "InventoryDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryDetail",
                table: "InventoryDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GoodReceivedNotes");

            migrationBuilder.RenameTable(
                name: "InventoryDetail",
                newName: "InventoryDetails");

            migrationBuilder.RenameTable(
                name: "Inventory",
                newName: "Inventories");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDetail_UnitId",
                table: "InventoryDetails",
                newName: "IX_InventoryDetails_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDetail_InventoryId",
                table: "InventoryDetails",
                newName: "IX_InventoryDetails_InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDetail_GrnId",
                table: "InventoryDetails",
                newName: "IX_InventoryDetails_GrnId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_ItemId",
                table: "Inventories",
                newName: "IX_Inventories_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_BaseUnitId",
                table: "Inventories",
                newName: "IX_Inventories_BaseUnitId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "GoodReceivedNotes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "SellingPrice",
                table: "InventoryDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasingPrice",
                table: "InventoryDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryDetails",
                table: "InventoryDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Units_BaseUnitId",
                table: "Inventories",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_ItemId",
                table: "Inventories",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDetails_GoodReceivedNotes_GrnId",
                table: "InventoryDetails",
                column: "GrnId",
                principalTable: "GoodReceivedNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDetails_Inventories_InventoryId",
                table: "InventoryDetails",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDetails_Units_UnitId",
                table: "InventoryDetails",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Units_BaseUnitId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_ItemId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDetails_GoodReceivedNotes_GrnId",
                table: "InventoryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDetails_Inventories_InventoryId",
                table: "InventoryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDetails_Units_UnitId",
                table: "InventoryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryDetails",
                table: "InventoryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "GoodReceivedNotes");

            migrationBuilder.RenameTable(
                name: "InventoryDetails",
                newName: "InventoryDetail");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "Inventory");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDetails_UnitId",
                table: "InventoryDetail",
                newName: "IX_InventoryDetail_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDetails_InventoryId",
                table: "InventoryDetail",
                newName: "IX_InventoryDetail_InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryDetails_GrnId",
                table: "InventoryDetail",
                newName: "IX_InventoryDetail_GrnId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_ItemId",
                table: "Inventory",
                newName: "IX_Inventory_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_BaseUnitId",
                table: "Inventory",
                newName: "IX_Inventory_BaseUnitId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GoodReceivedNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "SellingPrice",
                table: "InventoryDetail",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "PurchasingPrice",
                table: "InventoryDetail",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryDetail",
                table: "InventoryDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Units_BaseUnitId",
                table: "Inventory",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Items_ItemId",
                table: "Inventory",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDetail_GoodReceivedNotes_GrnId",
                table: "InventoryDetail",
                column: "GrnId",
                principalTable: "GoodReceivedNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDetail_Inventory_InventoryId",
                table: "InventoryDetail",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDetail_Units_UnitId",
                table: "InventoryDetail",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
