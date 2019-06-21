using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamiento.Repository.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comprobantes_Ingresos_ingresoId",
                table: "Comprobantes");

            migrationBuilder.RenameColumn(
                name: "Nombre_Localizacion",
                table: "Localizaciones",
                newName: "NombreLocalizacion");

            migrationBuilder.RenameColumn(
                name: "monto",
                table: "Comprobantes",
                newName: "Monto");

            migrationBuilder.RenameColumn(
                name: "ingresoId",
                table: "Comprobantes",
                newName: "IngresoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Comprobantes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comprobantes_ingresoId",
                table: "Comprobantes",
                newName: "IX_Comprobantes_IngresoId");

            migrationBuilder.RenameColumn(
                name: "Turno_Cajero",
                table: "Cajeros",
                newName: "TurnoCajero");

            migrationBuilder.RenameColumn(
                name: "Nombre_Cajero",
                table: "Cajeros",
                newName: "NombreCajero");

            migrationBuilder.AddForeignKey(
                name: "FK_Comprobantes_Ingresos_IngresoId",
                table: "Comprobantes",
                column: "IngresoId",
                principalTable: "Ingresos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comprobantes_Ingresos_IngresoId",
                table: "Comprobantes");

            migrationBuilder.RenameColumn(
                name: "NombreLocalizacion",
                table: "Localizaciones",
                newName: "Nombre_Localizacion");

            migrationBuilder.RenameColumn(
                name: "Monto",
                table: "Comprobantes",
                newName: "monto");

            migrationBuilder.RenameColumn(
                name: "IngresoId",
                table: "Comprobantes",
                newName: "ingresoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comprobantes",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Comprobantes_IngresoId",
                table: "Comprobantes",
                newName: "IX_Comprobantes_ingresoId");

            migrationBuilder.RenameColumn(
                name: "TurnoCajero",
                table: "Cajeros",
                newName: "Turno_Cajero");

            migrationBuilder.RenameColumn(
                name: "NombreCajero",
                table: "Cajeros",
                newName: "Nombre_Cajero");

            migrationBuilder.AddForeignKey(
                name: "FK_Comprobantes_Ingresos_ingresoId",
                table: "Comprobantes",
                column: "ingresoId",
                principalTable: "Ingresos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
