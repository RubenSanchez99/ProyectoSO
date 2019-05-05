using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProyectoSO.Migrations
{
    public partial class DomainEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(nullable: true),
                    ApellidoPaterno = table.Column<string>(nullable: true),
                    ApellidoMaterno = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MateriaId = table.Column<int>(nullable: false),
                    Capacidad = table.Column<int>(nullable: false),
                    Horario_Lunes = table.Column<string[]>(nullable: true),
                    Horario_Martes = table.Column<string[]>(nullable: true),
                    Horario_Miercoles = table.Column<string[]>(nullable: true),
                    Horario_Jueves = table.Column<string[]>(nullable: true),
                    Horario_Viernes = table.Column<string[]>(nullable: true),
                    Finalizado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Semestre = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    MateriaRequisitoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_Materias_MateriaRequisitoId",
                        column: x => x.MateriaRequisitoId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MateriaInscrita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MateriaId = table.Column<int>(nullable: false),
                    GrupoId = table.Column<int>(nullable: false),
                    Calificacion = table.Column<int>(nullable: true),
                    AlumnoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaInscrita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MateriaInscrita_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoInscrito",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Matricula = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Calificacion = table.Column<int>(nullable: true),
                    GrupoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoInscrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumnoInscrito_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoInscrito_GrupoId",
                table: "AlumnoInscrito",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaInscrita_AlumnoId",
                table: "MateriaInscrita",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_MateriaRequisitoId",
                table: "Materias",
                column: "MateriaRequisitoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoInscrito");

            migrationBuilder.DropTable(
                name: "MateriaInscrita");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Alumnos");
        }
    }
}
