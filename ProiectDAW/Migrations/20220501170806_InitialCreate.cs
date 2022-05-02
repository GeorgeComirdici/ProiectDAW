using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDAW.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adreseAngajatis",
                columns: table => new
                {
                    IdAdresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAngajat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adreseAngajatis", x => x.IdAdresa);
                });

            migrationBuilder.CreateTable(
                name: "departamentes",
                columns: table => new
                {
                    IdDepartament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeDepartament = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamentes", x => x.IdDepartament);
                });

            migrationBuilder.CreateTable(
                name: "proiectes",
                columns: table => new
                {
                    IdProiect = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetaliiProiect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proiectes", x => x.IdProiect);
                });

            migrationBuilder.CreateTable(
                name: "detaliiAngajatis",
                columns: table => new
                {
                    IdAngajat = table.Column<int>(type: "int", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salariu = table.Column<int>(type: "int", nullable: false),
                    foreignKeyDepartament = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detaliiAngajatis", x => x.IdAngajat);
                    table.ForeignKey(
                        name: "FK_detaliiAngajatis_adreseAngajatis_IdAngajat",
                        column: x => x.IdAngajat,
                        principalTable: "adreseAngajatis",
                        principalColumn: "IdAdresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detaliiAngajatis_departamentes_foreignKeyDepartament",
                        column: x => x.foreignKeyDepartament,
                        principalTable: "departamentes",
                        principalColumn: "IdDepartament",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proiecteAngajatis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProiect = table.Column<int>(type: "int", nullable: false),
                    IdAngajat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proiecteAngajatis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_proiecteAngajatis_detaliiAngajatis_IdAngajat",
                        column: x => x.IdAngajat,
                        principalTable: "detaliiAngajatis",
                        principalColumn: "IdAngajat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proiecteAngajatis_proiectes_IdProiect",
                        column: x => x.IdProiect,
                        principalTable: "proiectes",
                        principalColumn: "IdProiect",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detaliiAngajatis_foreignKeyDepartament",
                table: "detaliiAngajatis",
                column: "foreignKeyDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_proiecteAngajatis_IdAngajat",
                table: "proiecteAngajatis",
                column: "IdAngajat");

            migrationBuilder.CreateIndex(
                name: "IX_proiecteAngajatis_IdProiect",
                table: "proiecteAngajatis",
                column: "IdProiect");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "proiecteAngajatis");

            migrationBuilder.DropTable(
                name: "detaliiAngajatis");

            migrationBuilder.DropTable(
                name: "proiectes");

            migrationBuilder.DropTable(
                name: "adreseAngajatis");

            migrationBuilder.DropTable(
                name: "departamentes");
        }
    }
}
