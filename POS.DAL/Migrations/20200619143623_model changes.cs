using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DAL.Migrations
{
    public partial class modelchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "GoodReceivedNotes");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GoodReceivedNotes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "GoodReceivedNotes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "GoodReceivedNotes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "GrnDate",
                table: "GoodReceivedNotes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "GoodReceivedNoteItems",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBaseUnit",
                table: "GoodReceivedNoteItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "GoodReceivedNoteItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    BaseUnitId = table.Column<int>(nullable: false),
                    ReOrderLevel = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<string>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    UpdatedByName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Units_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(nullable: false),
                    GrnId = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: true),
                    StockInDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    IsBaseUnit = table.Column<bool>(nullable: false),
                    SellingPrice = table.Column<float>(nullable: false),
                    PurchasingPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryDetail_GoodReceivedNotes_GrnId",
                        column: x => x.GrnId,
                        principalTable: "GoodReceivedNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryDetail_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDetail_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceivedNoteItems_UnitId",
                table: "GoodReceivedNoteItems",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_BaseUnitId",
                table: "Inventory",
                column: "BaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemId",
                table: "Inventory",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetail_GrnId",
                table: "InventoryDetail",
                column: "GrnId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetail_InventoryId",
                table: "InventoryDetail",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetail_UnitId",
                table: "InventoryDetail",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceivedNoteItems_Units_UnitId",
                table: "GoodReceivedNoteItems",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceivedNoteItems_Units_UnitId",
                table: "GoodReceivedNoteItems");

            migrationBuilder.DropTable(
                name: "InventoryDetail");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_GoodReceivedNoteItems_UnitId",
                table: "GoodReceivedNoteItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GoodReceivedNotes");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "GoodReceivedNotes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "GoodReceivedNotes");

            migrationBuilder.DropColumn(
                name: "GrnDate",
                table: "GoodReceivedNotes");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "GoodReceivedNoteItems");

            migrationBuilder.DropColumn(
                name: "IsBaseUnit",
                table: "GoodReceivedNoteItems");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "GoodReceivedNoteItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "GoodReceivedNotes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
