using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoSO.Migrations
{
    public partial class MateriaSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "MateriaRequisitoId", "Nombre", "Semestre" },
                values: new object[,]
                {
                    { 1, null, "Matemáticas 1", 1 },
                    { 44, null, "Ética, Sociedad y Profesión", 7 },
                    { 43, null, "Minería de Datos", 7 },
                    { 40, null, "Cultura Regional", 6 },
                    { 39, null, "Competencia Comunicativa en Inglés", 6 },
                    { 38, null, "Seguridad en Informática", 6 },
                    { 34, null, "Contexto Social de la Profesión", 5 },
                    { 33, null, "Arquitecturas Avanzadas de Computadoras", 5 },
                    { 29, null, "Ambiente y Sustentabilidad", 4 },
                    { 23, null, "Cultura de Calidad", 3 },
                    { 20, null, "Procesamiento de Imágenes, Audio y Diálogos", 3 },
                    { 17, null, "Análisis de Sistemas I", 3 },
                    { 15, null, "Apreciación a las Artes", 2 },
                    { 8, null, "Competencia Comunicativa", 1 },
                    { 7, null, "Aplicación de las Tecnologías de la Información", 1 },
                    { 6, null, "Metodología de la Programación", 1 },
                    { 5, null, "Administración", 1 },
                    { 4, null, "Programación Orientada a Objetos", 1 },
                    { 3, null, "Principios de Arquitectura Computacional", 1 },
                    { 2, null, "Matemáticas 2", 1 },
                    { 45, null, "Metodología Científica", 7 },
                    { 46, null, "Formación de Emprendedores", 7 }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "MateriaRequisitoId", "Nombre", "Semestre" },
                values: new object[,]
                {
                    { 9, 2, "Matemáticas 3", 2 },
                    { 10, 2, "Matemáticas 4", 2 },
                    { 11, 2, "Física", 2 },
                    { 14, 3, "Teleinformática", 2 },
                    { 12, 4, "Programación I", 2 },
                    { 13, 5, "Comportamiento Organizacional", 2 }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "MateriaRequisitoId", "Nombre", "Semestre" },
                values: new object[,]
                {
                    { 16, 10, "Matemáticas Discretas", 3 },
                    { 22, 10, "Teoría de Autómatas", 3 },
                    { 18, 11, "Sistemas Electróncios", 3 },
                    { 28, 14, "Interconectividad de Redes", 4 },
                    { 19, 12, "Programación II", 3 },
                    { 21, 12, "Estructura de datos", 3 }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "MateriaRequisitoId", "Nombre", "Semestre" },
                values: new object[,]
                {
                    { 24, 16, "Ecuaciones Diferenciales", 4 },
                    { 25, 18, "Circuitos Digitales", 4 },
                    { 26, 21, "Bioinformática", 4 },
                    { 27, 21, "Base de Datos", 4 }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "MateriaRequisitoId", "Nombre", "Semestre" },
                values: new object[,]
                {
                    { 30, 24, "Estadística I", 5 },
                    { 31, 24, "Análisis Numérico", 5 },
                    { 32, 25, "Microprocesadores", 5 }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "MateriaRequisitoId", "Nombre", "Semestre" },
                values: new object[,]
                {
                    { 36, 30, "Estadística II", 6 },
                    { 35, 32, "Sistemas Embebidos I", 6 },
                    { 37, 32, "Sistemas Operativos", 6 }
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 34);

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
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
