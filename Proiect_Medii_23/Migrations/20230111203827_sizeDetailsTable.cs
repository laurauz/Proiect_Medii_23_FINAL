using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_23.Migrations
{
    public partial class sizeDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeDetails",
                table: "EchipamentSki");

            migrationBuilder.AddColumn<int>(
                name: "SizeDetailsID",
                table: "EchipamentSki",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SizeDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeDetails", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EchipamentSki_SizeDetailsID",
                table: "EchipamentSki",
                column: "SizeDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_EchipamentSki_SizeDetails_SizeDetailsID",
                table: "EchipamentSki",
                column: "SizeDetailsID",
                principalTable: "SizeDetails",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchipamentSki_SizeDetails_SizeDetailsID",
                table: "EchipamentSki");

            migrationBuilder.DropTable(
                name: "SizeDetails");

            migrationBuilder.DropIndex(
                name: "IX_EchipamentSki_SizeDetailsID",
                table: "EchipamentSki");

            migrationBuilder.DropColumn(
                name: "SizeDetailsID",
                table: "EchipamentSki");

            migrationBuilder.AddColumn<string>(
                name: "SizeDetails",
                table: "EchipamentSki",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
