using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDefinitivo.Migrations
{
    /// <inheritdoc />
    public partial class RelacaoAlunoxCurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DatadeAtualizacao", "DatadeCadastro", "Email", "Login", "Nome", "Perfil", "Senha" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin@admin.com", "Admin", "Ademiro", 1, "Admin123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
