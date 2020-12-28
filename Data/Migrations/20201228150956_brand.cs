using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_BusinessTypes_BusinessTypeId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_BusinessTypes_BusinessTypeId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "BusinessTypeId",
                table: "Categories",
                newName: "BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_BusinessTypeId",
                table: "Categories",
                newName: "IX_Categories_BusinessId");

            migrationBuilder.RenameColumn(
                name: "BusinessTypeId",
                table: "Brands",
                newName: "BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Brands_BusinessTypeId",
                table: "Brands",
                newName: "IX_Brands_BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Businesses_BusinessId",
                table: "Brands",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Businesses_BusinessId",
                table: "Categories",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Businesses_BusinessId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Businesses_BusinessId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Categories",
                newName: "BusinessTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_BusinessId",
                table: "Categories",
                newName: "IX_Categories_BusinessTypeId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Brands",
                newName: "BusinessTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Brands_BusinessId",
                table: "Brands",
                newName: "IX_Brands_BusinessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_BusinessTypes_BusinessTypeId",
                table: "Brands",
                column: "BusinessTypeId",
                principalTable: "BusinessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_BusinessTypes_BusinessTypeId",
                table: "Categories",
                column: "BusinessTypeId",
                principalTable: "BusinessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
