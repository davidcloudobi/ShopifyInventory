using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class sellUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sells_AspNetUsers_ApplicationUserId",
                table: "Sells");

            migrationBuilder.DropIndex(
                name: "IX_Sells_ApplicationUserId",
                table: "Sells");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sells");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sells",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sells_ApplicationUserId",
                table: "Sells",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sells_AspNetUsers_ApplicationUserId",
                table: "Sells",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
