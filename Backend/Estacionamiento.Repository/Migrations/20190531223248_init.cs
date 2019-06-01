using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamiento.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estacionamientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_Estacionamiento = table.Column<string>(nullable: true),
                    Numero_Espacios = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    localizacion_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estacionamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "localizaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_Localizacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localizaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuntoAtencion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ubicacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoAtencion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cajeros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_Cajero = table.Column<string>(nullable: true),
                    Turno_Cajero = table.Column<string>(nullable: true),
                    PuntoAtencionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cajeros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cajeros_PuntoAtencion_PuntoAtencionId",
                        column: x => x.PuntoAtencionId,
                        principalTable: "PuntoAtencion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CajeroId1 = table.Column<int>(nullable: true),
                    Placa = table.Column<string>(nullable: false),
                    HInicio = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresos_cajeros_CajeroId1",
                        column: x => x.CajeroId1,
                        principalTable: "cajeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cajeros_PuntoAtencionId",
                table: "cajeros",
                column: "PuntoAtencionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_CajeroId1",
                table: "Ingresos",
                column: "CajeroId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estacionamientos");

            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "localizaciones");

            migrationBuilder.DropTable(
                name: "cajeros");

            migrationBuilder.DropTable(
                name: "PuntoAtencion");
        }
    }
}
