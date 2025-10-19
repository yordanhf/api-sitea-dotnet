using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiSitea.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Paciente1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Municipios");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "Pacientes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Pacientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Municipios",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Municipios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ProvinciaId",
                table: "Pacientes",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Provincia_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Provincia_ProvinciaId",
                table: "Pacientes",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Provincia_ProvinciaId",
                table: "Municipios");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Provincia_ProvinciaId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_ProvinciaId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Municipios_ProvinciaId",
                table: "Municipios");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Municipios");

            migrationBuilder.AlterColumn<Guid>(
                name: "MunicipioId",
                table: "Pacientes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Pacientes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Municipios",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Municipios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
