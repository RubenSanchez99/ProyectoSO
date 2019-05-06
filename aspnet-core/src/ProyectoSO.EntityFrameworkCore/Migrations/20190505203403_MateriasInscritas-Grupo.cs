using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoSO.Migrations
{
    public partial class MateriasInscritasGrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.CreateIndex(
                name: "IX_MateriaInscrita_GrupoId",
                table: "MateriaInscrita",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaInscrita_Grupos_GrupoId",
                table: "MateriaInscrita",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriaInscrita_Grupos_GrupoId",
                table: "MateriaInscrita");

            migrationBuilder.DropIndex(
                name: "IX_MateriaInscrita_GrupoId",
                table: "MateriaInscrita");

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "MateriaRequisitoId", "Nombre", "Semestre" },
                values: new object[,]
                {
                    { 35, 32, "Sistemas Embebidos I", 6 },
                    { 36, 30, "Estadística II", 6 },
                    { 37, 32, "Sistemas Operativos", 6 },
                    { 38, null, "Seguridad en Informática", 6 },
                    { 39, null, "Competencia Comunicativa en Inglés", 6 },
                    { 40, null, "Cultura Regional", 6 },
                    { 43, null, "Minería de Datos", 7 },
                    { 44, null, "Ética, Sociedad y Profesión", 7 },
                    { 45, null, "Metodología Científica", 7 },
                    { 46, null, "Formación de Emprendedores", 7 }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "MateriaRequisitoId", "Nombre", "Semestre" },
                values: new object[,]
                {
                    { 41, 36, "Investigación de Operaciones", 7 },
                    { 42, 37, "Rendimiento de Sistemas", 7 }
                });
        }
    }
}
