using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigortam.DAL.Migrations
{
    public partial class db_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StTCKN",
                table: "Users",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StPlaka",
                table: "Users",
                column: "StPlaka");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StTCKN",
                table: "Users",
                column: "StTCKN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_StPlaka",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StTCKN",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "StTCKN",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }
    }
}
