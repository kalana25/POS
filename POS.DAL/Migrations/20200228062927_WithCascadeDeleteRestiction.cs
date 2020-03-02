using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DAL.Migrations
{
    public partial class WithCascadeDeleteRestiction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetail_Items_ItemId",
                table: "PurchaseOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetail_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrderDetail",
                table: "PurchaseOrderDetail");

            migrationBuilder.RenameTable(
                name: "PurchaseOrderDetail",
                newName: "PurchaseOrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderDetail_PurchaseOrderId",
                table: "PurchaseOrderDetails",
                newName: "IX_PurchaseOrderDetails_PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderDetail_ItemId",
                table: "PurchaseOrderDetails",
                newName: "IX_PurchaseOrderDetails_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrderDetails",
                table: "PurchaseOrderDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GoodReceivedNote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PurchaseOrderId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Comment = table.Column<int>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodReceivedNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodReceivedNote_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodReceivedNoteItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GoodReceivedNoteId = table.Column<int>(nullable: false),
                    PurchaseOrderDetailId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodReceivedNoteItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodReceivedNoteItem_GoodReceivedNote_GoodReceivedNoteId",
                        column: x => x.GoodReceivedNoteId,
                        principalTable: "GoodReceivedNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodReceivedNoteItem_PurchaseOrderDetails_PurchaseOrderDetailId",
                        column: x => x.PurchaseOrderDetailId,
                        principalTable: "PurchaseOrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceivedNote_PurchaseOrderId",
                table: "GoodReceivedNote",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceivedNoteItem_GoodReceivedNoteId",
                table: "GoodReceivedNoteItem",
                column: "GoodReceivedNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceivedNoteItem_PurchaseOrderDetailId",
                table: "GoodReceivedNoteItem",
                column: "PurchaseOrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_Items_ItemId",
                table: "PurchaseOrderDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_Items_ItemId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "GoodReceivedNoteItem");

            migrationBuilder.DropTable(
                name: "GoodReceivedNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrderDetails",
                table: "PurchaseOrderDetails");

            migrationBuilder.RenameTable(
                name: "PurchaseOrderDetails",
                newName: "PurchaseOrderDetail");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderDetails_PurchaseOrderId",
                table: "PurchaseOrderDetail",
                newName: "IX_PurchaseOrderDetail_PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderDetails_ItemId",
                table: "PurchaseOrderDetail",
                newName: "IX_PurchaseOrderDetail_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrderDetail",
                table: "PurchaseOrderDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetail_Items_ItemId",
                table: "PurchaseOrderDetail",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetail_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetail",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
