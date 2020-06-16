using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DAL.Migrations
{
    public partial class unitissuefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseUnits_BaseUnits_BaseUnitId",
                table: "PurchaseUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseUnits_Items_ItemId",
                table: "PurchaseUnits");

            migrationBuilder.DropTable(
                name: "BaseUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseUnits",
                table: "PurchaseUnits");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "PurchaseOrderDetails");

            migrationBuilder.RenameTable(
                name: "PurchaseUnits",
                newName: "Units");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseUnits_ItemId",
                table: "Units",
                newName: "IX_Units_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseUnits_BaseUnitId",
                table: "Units",
                newName: "IX_Units_BaseUnitId");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "PurchaseOrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Units",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Units",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Units",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BaseUnitId",
                table: "Units",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Units",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetails_UnitId",
                table: "PurchaseOrderDetails",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_Units_UnitId",
                table: "PurchaseOrderDetails",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Units_BaseUnitId",
                table: "Units",
                column: "BaseUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Items_ItemId",
                table: "Units",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_Units_UnitId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Units_BaseUnitId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Items_ItemId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderDetails_UnitId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Units");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "PurchaseUnits");

            migrationBuilder.RenameIndex(
                name: "IX_Units_ItemId",
                table: "PurchaseUnits",
                newName: "IX_PurchaseUnits_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Units_BaseUnitId",
                table: "PurchaseUnits",
                newName: "IX_PurchaseUnits_BaseUnitId");

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "PurchaseOrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "PurchaseUnits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PurchaseUnits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "PurchaseUnits",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "PurchaseUnits",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaseUnitId",
                table: "PurchaseUnits",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseUnits",
                table: "PurchaseUnits",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BaseUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUnits", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseUnits_BaseUnits_BaseUnitId",
                table: "PurchaseUnits",
                column: "BaseUnitId",
                principalTable: "BaseUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseUnits_Items_ItemId",
                table: "PurchaseUnits",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
