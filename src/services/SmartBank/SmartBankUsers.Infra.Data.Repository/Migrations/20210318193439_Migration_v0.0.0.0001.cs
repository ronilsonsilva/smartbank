using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBank.Infra.Data.Repository.Migrations
{
    public partial class Migration_v0000001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    rg = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    cnh = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sexo = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    telefone_fixo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    telelefone_celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    endereco_cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    endreco_logradouro = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    endreco_complemento = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    endreco_numero = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    endereco_bairro = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    endereco_cidade = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    cidade_codigo_ibge = table.Column<int>(type: "integer", nullable: true),
                    nome_mae = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    nome_pai = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    escolaridade = table.Column<int>(type: "integer", nullable: false),
                    empresa_trabalho_nome_fantasia = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    empresa_trabalho_razao_social = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    empresa_trabalho_cnpj = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    empresa_trabalho_cep = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    empresa_trabalho_endereco_logradouro = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    empresa_trabalho_endereco_complemento = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    empresa_trabalho_endereco_numero = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    empresa_trabalho_bairro = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    empresa_trabalho_cidade = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    empresa_trabalho_cidade_ibge = table.Column<int>(type: "integer", maxLength: 256, nullable: true),
                    empresa_trabalho_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    empresa_trabalho_telefone = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    empresa_trabalho_celular = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Usuario = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 18, 16, 34, 38, 735, DateTimeKind.Local).AddTicks(9427)),
                    Atualizado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
