using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dbRemodeling2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OutletId",
                table: "Inventories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_OutletId",
                table: "Inventories",
                column: "OutletId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Outlets_OutletId",
                table: "Inventories",
                column: "OutletId",
                principalTable: "Outlets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Outlets_OutletId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_OutletId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "OutletId",
                table: "Inventories");
        }
    }
}
