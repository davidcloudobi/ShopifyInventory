using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class outlet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Outlets",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Outlets_ApplicationUserId",
                table: "Outlets",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Outlets_AspNetUsers_ApplicationUserId",
                table: "Outlets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outlets_AspNetUsers_ApplicationUserId",
                table: "Outlets");

            migrationBuilder.DropIndex(
                name: "IX_Outlets_ApplicationUserId",
                table: "Outlets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Outlets");
        }
    }
}
