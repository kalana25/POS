using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DAL.Migrations
{
    public partial class dotnetcore3test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceivedNote_PurchaseOrders_PurchaseOrderId",
                table: "GoodReceivedNote");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceivedNoteItem_GoodReceivedNote_GoodReceivedNoteId",
                table: "GoodReceivedNoteItem");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceivedNoteItem_PurchaseOrderDetails_PurchaseOrderDetailId",
                table: "GoodReceivedNoteItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplerContacts_Suppliers_SupplierId",
                table: "SupplerContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplerContacts",
                table: "SupplerContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoodReceivedNoteItem",
                table: "GoodReceivedNoteItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoodReceivedNote",
                table: "GoodReceivedNote");

            migrationBuilder.RenameTable(
                name: "SupplerContacts",
                newName: "SupplierContacts");

            migrationBuilder.RenameTable(
                name: "GoodReceivedNoteItem",
                newName: "GoodReceivedNoteItems");

            migrationBuilder.RenameTable(
                name: "GoodReceivedNote",
                newName: "GoodReceivedNotes");

            migrationBuilder.RenameIndex(
                name: "IX_SupplerContacts_SupplierId",
                table: "SupplierContacts",
                newName: "IX_SupplierContacts_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_GoodReceivedNoteItem_PurchaseOrderDetailId",
                table: "GoodReceivedNoteItems",
                newName: "IX_GoodReceivedNoteItems_PurchaseOrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_GoodReceivedNoteItem_GoodReceivedNoteId",
                table: "GoodReceivedNoteItems",
                newName: "IX_GoodReceivedNoteItems_GoodReceivedNoteId");

            migrationBuilder.RenameIndex(
                name: "IX_GoodReceivedNote_PurchaseOrderId",
                table: "GoodReceivedNotes",
                newName: "IX_GoodReceivedNotes_PurchaseOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierContacts",
                table: "SupplierContacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoodReceivedNoteItems",
                table: "GoodReceivedNoteItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoodReceivedNotes",
                table: "GoodReceivedNotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceivedNoteItems_GoodReceivedNotes_GoodReceivedNoteId",
                table: "GoodReceivedNoteItems",
                column: "GoodReceivedNoteId",
                principalTable: "GoodReceivedNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceivedNoteItems_PurchaseOrderDetails_PurchaseOrderDetailId",
                table: "GoodReceivedNoteItems",
                column: "PurchaseOrderDetailId",
                principalTable: "PurchaseOrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceivedNotes_PurchaseOrders_PurchaseOrderId",
                table: "GoodReceivedNotes",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierContacts_Suppliers_SupplierId",
                table: "SupplierContacts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceivedNoteItems_GoodReceivedNotes_GoodReceivedNoteId",
                table: "GoodReceivedNoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceivedNoteItems_PurchaseOrderDetails_PurchaseOrderDetailId",
                table: "GoodReceivedNoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceivedNotes_PurchaseOrders_PurchaseOrderId",
                table: "GoodReceivedNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierContacts_Suppliers_SupplierId",
                table: "SupplierContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierContacts",
                table: "SupplierContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoodReceivedNotes",
                table: "GoodReceivedNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoodReceivedNoteItems",
                table: "GoodReceivedNoteItems");

            migrationBuilder.RenameTable(
                name: "SupplierContacts",
                newName: "SupplerContacts");

            migrationBuilder.RenameTable(
                name: "GoodReceivedNotes",
                newName: "GoodReceivedNote");

            migrationBuilder.RenameTable(
                name: "GoodReceivedNoteItems",
                newName: "GoodReceivedNoteItem");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierContacts_SupplierId",
                table: "SupplerContacts",
                newName: "IX_SupplerContacts_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_GoodReceivedNotes_PurchaseOrderId",
                table: "GoodReceivedNote",
                newName: "IX_GoodReceivedNote_PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_GoodReceivedNoteItems_PurchaseOrderDetailId",
                table: "GoodReceivedNoteItem",
                newName: "IX_GoodReceivedNoteItem_PurchaseOrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_GoodReceivedNoteItems_GoodReceivedNoteId",
                table: "GoodReceivedNoteItem",
                newName: "IX_GoodReceivedNoteItem_GoodReceivedNoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplerContacts",
                table: "SupplerContacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoodReceivedNote",
                table: "GoodReceivedNote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoodReceivedNoteItem",
                table: "GoodReceivedNoteItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceivedNote_PurchaseOrders_PurchaseOrderId",
                table: "GoodReceivedNote",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceivedNoteItem_GoodReceivedNote_GoodReceivedNoteId",
                table: "GoodReceivedNoteItem",
                column: "GoodReceivedNoteId",
                principalTable: "GoodReceivedNote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceivedNoteItem_PurchaseOrderDetails_PurchaseOrderDetailId",
                table: "GoodReceivedNoteItem",
                column: "PurchaseOrderDetailId",
                principalTable: "PurchaseOrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplerContacts_Suppliers_SupplierId",
                table: "SupplerContacts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
