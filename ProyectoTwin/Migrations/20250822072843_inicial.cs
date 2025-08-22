using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoTwin.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentesTwin",
                columns: table => new
                {
                    IdComponente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoDatos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstadoReal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstadoDigital = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UltimaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndicadorSostenibilidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MantenimientoProgramado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentesTwin", x => x.IdComponente);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentesTwin");
        }
    }
}
