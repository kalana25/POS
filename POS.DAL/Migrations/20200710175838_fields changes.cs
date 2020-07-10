using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DAL.Migrations
{
    public partial class fieldschanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PurchasingPrice",
                table: "GoodReceivedNoteItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SellingPrice",
                table: "GoodReceivedNoteItems",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasingPrice",
                table: "GoodReceivedNoteItems");

            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "GoodReceivedNoteItems");
        }
    }
}
