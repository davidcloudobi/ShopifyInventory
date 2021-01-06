using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dbRemodeling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Businesses_BusinessId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Outlets_OutletId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_BusinessId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_OutletId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ProductId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "OutletId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Inventories");

            migrationBuilder.CreateTable(
                name: "InventoryProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false),
                    InventoryId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryProducts_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProducts_InventoryId",
                table: "InventoryProducts",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProducts_ProductId",
                table: "InventoryProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Inventories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OutletId",
                table: "Inventories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Inventories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BusinessId",
                table: "Inventories",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_OutletId",
                table: "Inventories",
                column: "OutletId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductId",
                table: "Inventories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Businesses_BusinessId",
                table: "Inventories",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Outlets_OutletId",
                table: "Inventories",
                column: "OutletId",
                principalTable: "Outlets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductId",
                table: "Inventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
