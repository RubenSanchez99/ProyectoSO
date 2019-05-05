using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoSO.Migrations
{
    public partial class Horario_Bool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Horario_Hora",
                table: "Grupos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Horario_Jueves",
                table: "Grupos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Horario_Lunes",
                table: "Grupos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Horario_Martes",
                table: "Grupos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Horario_Miercoles",
                table: "Grupos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Horario_Viernes",
                table: "Grupos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horario_Hora",
                table: "Grupos");

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
        }
    }
}
