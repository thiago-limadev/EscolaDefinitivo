using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDefinitivo.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarEnderecoAlunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatadeCadastro", "Senha" },
                values: new object[] { new DateTime(2023, 10, 11, 5, 56, 54, 428, DateTimeKind.Local).AddTicks(8499), "7af2d10b73ab7cd8f603937f7697cb5fe432c7ff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Alunos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatadeCadastro", "Senha" },
                values: new object[] { new DateTime(2023, 9, 26, 20, 26, 55, 758, DateTimeKind.Local).AddTicks(3759), "Admin123" });
        }
    }
}
