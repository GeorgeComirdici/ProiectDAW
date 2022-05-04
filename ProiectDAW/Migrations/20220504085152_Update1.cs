using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDAW.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detaliiAngajatis_departamentes_foreignKeyDepartament",
                table: "detaliiAngajatis");

            migrationBuilder.RenameColumn(
                name: "foreignKeyDepartament",
                table: "detaliiAngajatis",
                newName: "IdDepartament");

            migrationBuilder.RenameIndex(
                name: "IX_detaliiAngajatis_foreignKeyDepartament",
                table: "detaliiAngajatis",
                newName: "IX_detaliiAngajatis_IdDepartament");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "detaliiAngajatis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_detaliiAngajatis_departamentes_IdDepartament",
                table: "detaliiAngajatis",
                column: "IdDepartament",
                principalTable: "departamentes",
                principalColumn: "IdDepartament",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detaliiAngajatis_departamentes_IdDepartament",
                table: "detaliiAngajatis");

            migrationBuilder.RenameColumn(
                name: "IdDepartament",
                table: "detaliiAngajatis",
                newName: "foreignKeyDepartament");

            migrationBuilder.RenameIndex(
                name: "IX_detaliiAngajatis_IdDepartament",
                table: "detaliiAngajatis",
                newName: "IX_detaliiAngajatis_foreignKeyDepartament");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "detaliiAngajatis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_detaliiAngajatis_departamentes_foreignKeyDepartament",
                table: "detaliiAngajatis",
                column: "foreignKeyDepartament",
                principalTable: "departamentes",
                principalColumn: "IdDepartament",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
