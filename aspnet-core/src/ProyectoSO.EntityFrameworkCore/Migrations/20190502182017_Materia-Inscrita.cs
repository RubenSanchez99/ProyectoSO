using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoSO.Migrations
{
    public partial class MateriaInscrita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MateriaInscrita_MateriaId",
                table: "MateriaInscrita",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaInscrita_Materias_MateriaId",
                table: "MateriaInscrita",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriaInscrita_Materias_MateriaId",
                table: "MateriaInscrita");

            migrationBuilder.DropIndex(
                name: "IX_MateriaInscrita_MateriaId",
                table: "MateriaInscrita");
        }
    }
}
