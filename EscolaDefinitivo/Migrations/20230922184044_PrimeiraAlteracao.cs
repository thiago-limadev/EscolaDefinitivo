using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDefinitivo.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraAlteracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Periodo",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Curso_Matriculado",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Curso_Matriculado",
                table: "Alunos");
        }
    }
}
