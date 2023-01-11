using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_23.Migrations
{
    public partial class Brander : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "EchipamentSki",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EchipamentSki_BrandID",
                table: "EchipamentSki",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_EchipamentSki_Brand_BrandID",
                table: "EchipamentSki",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchipamentSki_Brand_BrandID",
                table: "EchipamentSki");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_EchipamentSki_BrandID",
                table: "EchipamentSki");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "EchipamentSki");
        }
    }
}
