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
                name: "Localizaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_Localizacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuntoAtenciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ubicacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoAtenciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarifas",
                columns: table => new
                {
                    TarifaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Monto = table.Column<double>(nullable: false),
                    TipoVehiculo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifas", x => x.TarifaId);
                });

            migrationBuilder.CreateTable(
                name: "estacionamientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_Estacionamiento = table.Column<string>(nullable: true),
                    Numero_Espacios = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    LocalizacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estacionamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estacionamientos_Localizaciones_LocalizacionId",
                        column: x => x.LocalizacionId,
                        principalTable: "Localizaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cajeros",
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
                    table.PrimaryKey("PK_Cajeros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cajeros_PuntoAtenciones_PuntoAtencionId",
                        column: x => x.PuntoAtencionId,
                        principalTable: "PuntoAtenciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Espacios",
                columns: table => new
                {
                    EspacioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Disponible = table.Column<bool>(nullable: false),
                    EstacionamientosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espacios", x => x.EspacioId);
                    table.ForeignKey(
                        name: "FK_Espacios_estacionamientos_EstacionamientosId",
                        column: x => x.EstacionamientosId,
                        principalTable: "estacionamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TarifaId = table.Column<int>(nullable: false),
                    CajeroId = table.Column<int>(nullable: false),
                    Placa = table.Column<string>(nullable: false),
                    HInicio = table.Column<DateTime>(nullable: false),
                    EspacioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresos_Cajeros_CajeroId",
                        column: x => x.CajeroId,
                        principalTable: "Cajeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingresos_Tarifas_TarifaId",
                        column: x => x.TarifaId,
                        principalTable: "Tarifas",
                        principalColumn: "TarifaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comprobantes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ingresoId = table.Column<int>(nullable: false),
                    horaIni = table.Column<DateTime>(nullable: false),
                    horaFin = table.Column<DateTime>(nullable: false),
                    monto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobantes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comprobantes_Ingresos_ingresoId",
                        column: x => x.ingresoId,
                        principalTable: "Ingresos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cajeros_PuntoAtencionId",
                table: "Cajeros",
                column: "PuntoAtencionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_ingresoId",
                table: "Comprobantes",
                column: "ingresoId");

            migrationBuilder.CreateIndex(
                name: "IX_Espacios_EstacionamientosId",
                table: "Espacios",
                column: "EstacionamientosId");

            migrationBuilder.CreateIndex(
                name: "IX_estacionamientos_LocalizacionId",
                table: "estacionamientos",
                column: "LocalizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_CajeroId",
                table: "Ingresos",
                column: "CajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_TarifaId",
                table: "Ingresos",
                column: "TarifaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comprobantes");

            migrationBuilder.DropTable(
                name: "Espacios");

            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "estacionamientos");

            migrationBuilder.DropTable(
                name: "Cajeros");

            migrationBuilder.DropTable(
                name: "Tarifas");

            migrationBuilder.DropTable(
                name: "Localizaciones");

            migrationBuilder.DropTable(
                name: "PuntoAtenciones");
        }
    }
}
