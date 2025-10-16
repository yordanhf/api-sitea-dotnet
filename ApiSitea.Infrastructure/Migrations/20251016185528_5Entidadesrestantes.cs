using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiSitea.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _5Entidadesrestantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fortalezas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fortalezas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposExamen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposExamen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposInterconsulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposInterconsulta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VinculosInstitucionales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculosInstitucionales", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Fortalezas");

            migrationBuilder.DropTable(
                name: "TiposExamen");

            migrationBuilder.DropTable(
                name: "TiposInterconsulta");

            migrationBuilder.DropTable(
                name: "VinculosInstitucionales");
        }
    }
}
