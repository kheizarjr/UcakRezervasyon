using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guzergah",
                columns: table => new
                {
                    guzergahId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guzergah", x => x.guzergahId);
                });

            migrationBuilder.CreateTable(
                name: "ucak",
                columns: table => new
                {
                    ucakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ucakName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    koltukSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ucak", x => x.ucakId);
                });

            migrationBuilder.CreateTable(
                name: "ucakdetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ucakdetay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ucus",
                columns: table => new
                {
                    ucusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ucakId = table.Column<int>(type: "int", nullable: false),
                    guzergahId = table.Column<int>(type: "int", nullable: false),
                    koltukNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ucus", x => x.ucusId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guzergah");

            migrationBuilder.DropTable(
                name: "ucak");

            migrationBuilder.DropTable(
                name: "ucakdetay");

            migrationBuilder.DropTable(
                name: "ucus");
        }
    }
}
