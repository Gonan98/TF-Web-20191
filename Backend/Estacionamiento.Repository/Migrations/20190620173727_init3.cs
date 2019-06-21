using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamiento.Repository.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_EspacioId",
                table: "Ingresos",
                column: "EspacioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresos_Espacios_EspacioId",
                table: "Ingresos",
                column: "EspacioId",
                principalTable: "Espacios",
                principalColumn: "EspacioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresos_Espacios_EspacioId",
                table: "Ingresos");

            migrationBuilder.DropIndex(
                name: "IX_Ingresos_EspacioId",
                table: "Ingresos");
        }
    }
}
