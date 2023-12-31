using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyon.Migrations
{
    public partial class NewFirstModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "guzergahName",
                table: "ucus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ucus_guzergahId",
                table: "ucus",
                column: "guzergahId");

            migrationBuilder.CreateIndex(
                name: "IX_ucus_ucakId",
                table: "ucus",
                column: "ucakId");

            migrationBuilder.AddForeignKey(
                name: "FK_ucus_guzergah_guzergahId",
                table: "ucus",
                column: "guzergahId",
                principalTable: "guzergah",
                principalColumn: "guzergahId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ucus_ucak_ucakId",
                table: "ucus",
                column: "ucakId",
                principalTable: "ucak",
                principalColumn: "ucakId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ucus_guzergah_guzergahId",
                table: "ucus");

            migrationBuilder.DropForeignKey(
                name: "FK_ucus_ucak_ucakId",
                table: "ucus");

            migrationBuilder.DropIndex(
                name: "IX_ucus_guzergahId",
                table: "ucus");

            migrationBuilder.DropIndex(
                name: "IX_ucus_ucakId",
                table: "ucus");

            migrationBuilder.DropColumn(
                name: "guzergahName",
                table: "ucus");
        }
    }
}
