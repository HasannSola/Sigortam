using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigortam.DAL.Migrations
{
    public partial class db_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    InUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StPlaka = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StTCKN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StRuhsatSeriKodu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StRuhsatSeriNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.InUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
