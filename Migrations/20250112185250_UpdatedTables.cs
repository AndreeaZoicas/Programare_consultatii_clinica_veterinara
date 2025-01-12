using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programare_consultatii_clinica_veterinara.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacient_Proprietar_ProprietarID",
                table: "Pacient");

            migrationBuilder.AlterColumn<int>(
                name: "ProprietarID",
                table: "Pacient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacient_Proprietar_ProprietarID",
                table: "Pacient",
                column: "ProprietarID",
                principalTable: "Proprietar",
                principalColumn: "ProprietarID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacient_Proprietar_ProprietarID",
                table: "Pacient");

            migrationBuilder.AlterColumn<int>(
                name: "ProprietarID",
                table: "Pacient",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacient_Proprietar_ProprietarID",
                table: "Pacient",
                column: "ProprietarID",
                principalTable: "Proprietar",
                principalColumn: "ProprietarID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
