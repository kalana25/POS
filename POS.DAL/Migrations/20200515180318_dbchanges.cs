using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DAL.Migrations
{
    public partial class dbchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PurchaseOrders");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PurchaseOrders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "PurchaseOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "PurchaseOrders");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "PurchaseOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PurchaseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
