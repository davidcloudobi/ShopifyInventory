using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class sellUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sells_Customers_CustomerId",
                table: "Sells");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Sells",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddForeignKey(
                name: "FK_Sells_Customers_CustomerId",
                table: "Sells",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sells_Customers_CustomerId",
                table: "Sells");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Sells",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sells_Customers_CustomerId",
                table: "Sells",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
