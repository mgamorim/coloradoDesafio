using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoDesafio.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    TipoPessoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DataInformacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visualizado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "TiposTelefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTelefone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    NumeroTelefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCliente = table.Column<int>(type: "int", nullable: false),
                    TipoTelefone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DDD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DDI = table.Column<int>(type: "int", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.NumeroTelefone);
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_CodigoCliente",
                        column: x => x.CodigoCliente,
                        principalTable: "Clientes",
                        principalColumn: "CodigoCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposTelefone",
                columns: new[] { "Id", "Ativo", "Descricao" },
                values: new object[,]
                {
                    { 1, true, "RESIDENCIAL" },
                    { 2, true, "COMERCIAL" },
                    { 3, true, "WHATSAPP" },
                    { 4, true, "CELULAR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_CodigoCliente",
                table: "Telefones",
                column: "CodigoCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "TiposTelefone");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
