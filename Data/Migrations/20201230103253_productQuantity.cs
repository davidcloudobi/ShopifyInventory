using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class productQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "SellItems",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "SellItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");
        }
    }
}
