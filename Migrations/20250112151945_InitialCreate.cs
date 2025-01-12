using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programare_consultatii_clinica_veterinara.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medic",
                columns: table => new
                {
                    MedicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specializare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperientaAni = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic", x => x.MedicID);
                });

            migrationBuilder.CreateTable(
                name: "Proprietar",
                columns: table => new
                {
                    ProprietarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietar", x => x.ProprietarID);
                });

            migrationBuilder.CreateTable(
                name: "Pacient",
                columns: table => new
                {
                    PacientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNasterii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProprietarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacient", x => x.PacientID);
                    table.ForeignKey(
                        name: "FK_Pacient_Proprietar_ProprietarID",
                        column: x => x.ProprietarID,
                        principalTable: "Proprietar",
                        principalColumn: "ProprietarID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultatie",
                columns: table => new
                {
                    ConsultatieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ora = table.Column<TimeSpan>(type: "time", nullable: false),
                    MedicID = table.Column<int>(type: "int", nullable: false),
                    PacientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultatie", x => x.ConsultatieID);
                    table.ForeignKey(
                        name: "FK_Consultatie_Medic_MedicID",
                        column: x => x.MedicID,
                        principalTable: "Medic",
                        principalColumn: "MedicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultatie_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "PacientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzie",
                columns: table => new
                {
                    RecenzieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicID = table.Column<int>(type: "int", nullable: false),
                    PacientID = table.Column<int>(type: "int", nullable: false),
                    Scor = table.Column<int>(type: "int", nullable: false),
                    Comentariu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzie", x => x.RecenzieID);
                    table.ForeignKey(
                        name: "FK_Recenzie_Medic_MedicID",
                        column: x => x.MedicID,
                        principalTable: "Medic",
                        principalColumn: "MedicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recenzie_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "PacientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultatie_MedicID",
                table: "Consultatie",
                column: "MedicID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultatie_PacientID",
                table: "Consultatie",
                column: "PacientID");

            migrationBuilder.CreateIndex(
                name: "IX_Pacient_ProprietarID",
                table: "Pacient",
                column: "ProprietarID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzie_MedicID",
                table: "Recenzie",
                column: "MedicID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzie_PacientID",
                table: "Recenzie",
                column: "PacientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultatie");

            migrationBuilder.DropTable(
                name: "Recenzie");

            migrationBuilder.DropTable(
                name: "Medic");

            migrationBuilder.DropTable(
                name: "Pacient");

            migrationBuilder.DropTable(
                name: "Proprietar");
        }
    }
}
