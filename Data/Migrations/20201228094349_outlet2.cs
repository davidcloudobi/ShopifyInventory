using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class outlet2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ApplicationUserOutlet",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    OutletsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserOutlet", x => new { x.ApplicationUsersId, x.OutletsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserOutlet_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserOutlet_Outlets_OutletsId",
                        column: x => x.OutletsId,
                        principalTable: "Outlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserOutlet_OutletsId",
                table: "ApplicationUserOutlet",
                column: "OutletsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserOutlet");

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
    }
}
