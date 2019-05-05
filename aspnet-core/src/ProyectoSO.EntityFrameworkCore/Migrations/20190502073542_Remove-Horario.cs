using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoSO.Migrations
{
    public partial class RemoveHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horario_Jueves",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "Horario_Lunes",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "Horario_Martes",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "Horario_Miercoles",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "Horario_Viernes",
                table: "Grupos");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_MateriaId",
                table: "Grupos",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Materias_MateriaId",
                table: "Grupos",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materias_MateriaId",
                table: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_MateriaId",
                table: "Grupos");

            migrationBuilder.AddColumn<string[]>(
                name: "Horario_Jueves",
                table: "Grupos",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Horario_Lunes",
                table: "Grupos",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Horario_Martes",
                table: "Grupos",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Horario_Miercoles",
                table: "Grupos",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Horario_Viernes",
                table: "Grupos",
                nullable: true);
        }
    }
}
