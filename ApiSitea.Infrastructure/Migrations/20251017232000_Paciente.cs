using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiSitea.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Paciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Provincia = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Ci = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Sexo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Raza = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    MotivoConsulta = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Correo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    AntecedentesPF = table.Column<string>(type: "TEXT", nullable: true),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true),
                    Verbal = table.Column<bool>(type: "INTEGER", nullable: false),
                    EdadDiagnostico = table.Column<int>(type: "INTEGER", nullable: true),
                    FechaDiagnostico = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Terapia = table.Column<bool>(type: "INTEGER", nullable: false),
                    DescripcionTerapia = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Provincia = table.Column<string>(type: "TEXT", nullable: false),
                    MunicipioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CentroId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DiagnosticoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VinculoInstitucionalId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Centros_CentroId",
                        column: x => x.CentroId,
                        principalTable: "Centros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Diagnosticos_DiagnosticoId",
                        column: x => x.DiagnosticoId,
                        principalTable: "Diagnosticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_VinculosInstitucionales_VinculoInstitucionalId",
                        column: x => x.VinculoInstitucionalId,
                        principalTable: "VinculosInstitucionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Apellidos",
                table: "Pacientes",
                column: "Apellidos");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CentroId",
                table: "Pacientes",
                column: "CentroId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Ci",
                table: "Pacientes",
                column: "Ci",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_DiagnosticoId",
                table: "Pacientes",
                column: "DiagnosticoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_MunicipioId",
                table: "Pacientes",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Nombre",
                table: "Pacientes",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_VinculoInstitucionalId",
                table: "Pacientes",
                column: "VinculoInstitucionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Municipios");
        }
    }
}
