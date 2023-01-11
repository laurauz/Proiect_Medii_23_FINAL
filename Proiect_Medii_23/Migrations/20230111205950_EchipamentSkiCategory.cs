using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_23.Migrations
{
    public partial class EchipamentSkiCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EchipamentSkiCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EchipamentSkiID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EchipamentSkiCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EchipamentSkiCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EchipamentSkiCategory_EchipamentSki_EchipamentSkiID",
                        column: x => x.EchipamentSkiID,
                        principalTable: "EchipamentSki",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EchipamentSkiCategory_CategoryID",
                table: "EchipamentSkiCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_EchipamentSkiCategory_EchipamentSkiID",
                table: "EchipamentSkiCategory",
                column: "EchipamentSkiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EchipamentSkiCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
