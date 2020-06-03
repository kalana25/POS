using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.DAL.Migrations
{
    public partial class PurchaseUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    BaseUnitId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseUnits_BaseUnits_BaseUnitId",
                        column: x => x.BaseUnitId,
                        principalTable: "BaseUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseUnits_BaseUnitId",
                table: "PurchaseUnits",
                column: "BaseUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseUnits");
        }
    }
}
