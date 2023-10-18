using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDefinitivo.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoNumeroEmAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatadeCadastro",
                value: new DateTime(2023, 10, 11, 15, 24, 12, 651, DateTimeKind.Local).AddTicks(2929));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Alunos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatadeCadastro",
                value: new DateTime(2023, 10, 11, 5, 56, 54, 428, DateTimeKind.Local).AddTicks(8499));
        }
    }
}
