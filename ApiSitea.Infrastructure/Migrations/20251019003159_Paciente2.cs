using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiSitea.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Paciente2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Provincia_ProvinciaId",
                table: "Municipios");

            migrationBuilder.DropIndex(
                name: "IX_Municipios_ProvinciaId",
                table: "Municipios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
