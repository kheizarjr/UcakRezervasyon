using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Migrations
{
    public partial class Yenieklemee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "guzergahName",
                table: "ucus");

            migrationBuilder.DropColumn(
                name: "koltukNo",
                table: "ucus");

            migrationBuilder.CreateTable(
                name: "rezervasyon",
                columns: table => new
                {
                    rezervasyonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ucusId = table.Column<int>(type: "int", nullable: false),
                    KoltukNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervasyon", x => x.rezervasyonId);
                    table.ForeignKey(
                        name: "FK_rezervasyon_ucus_ucusId",
                        column: x => x.ucusId,
                        principalTable: "ucus",
                        principalColumn: "ucusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rezervasyon_ucusId",
                table: "rezervasyon",
                column: "ucusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rezervasyon");

            migrationBuilder.AddColumn<string>(
                name: "guzergahName",
                table: "ucus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "koltukNo",
                table: "ucus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
