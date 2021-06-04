using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBank.Infra.Data.Repository.Migrations
{
    public partial class Migration_v000001 : Migration
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
                    data_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 4, 1, 38, 47, 901, DateTimeKind.Local).AddTicks(5724)),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 4, 1, 38, 47, 907, DateTimeKind.Local).AddTicks(7419))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cliente_biometria_digital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    biometria_base64 = table.Column<string>(type: "text", nullable: false),
                    posicao = table.Column<int>(type: "integer", nullable: false),
                    similaridade = table.Column<int>(type: "integer", nullable: false),
                    propabilidade = table.Column<string>(type: "text", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 4, 1, 38, 47, 965, DateTimeKind.Local).AddTicks(7003)),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 4, 1, 38, 47, 965, DateTimeKind.Local).AddTicks(8328))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_biometria_digital", x => x.Id);
                    table.ForeignKey(
                        name: "fk_cliente__cliente_biometria_digital",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cliente_solicitacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    data = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 4, 1, 38, 47, 974, DateTimeKind.Local).AddTicks(5570)),
                    tipo = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    valor_liberado = table.Column<decimal>(type: "numeric", nullable: false),
                    valo_liberado = table.Column<decimal>(type: "numeric", nullable: false),
                    data_aprovacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    data_cancelamento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 4, 1, 38, 47, 986, DateTimeKind.Local).AddTicks(687)),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 4, 1, 38, 47, 986, DateTimeKind.Local).AddTicks(4134))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_solicitacao", x => x.Id);
                    table.ForeignKey(
                        name: "fk_cliente__cliente_solicitacoes",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cliente_solicitacao_pendencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_pendencia = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 4, 1, 38, 47, 992, DateTimeKind.Local).AddTicks(498)),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    data_resolvida = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    descricao = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    resolucao = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    solicitacao_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 4, 1, 38, 47, 995, DateTimeKind.Local).AddTicks(6118)),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 4, 1, 38, 47, 995, DateTimeKind.Local).AddTicks(7069))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_solicitacao_pendencia", x => x.Id);
                    table.ForeignKey(
                        name: "fk_solicitacao__pendencia_solicitacao",
                        column: x => x.solicitacao_id,
                        principalTable: "cliente_solicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_biometria_digital_cliente_id",
                table: "cliente_biometria_digital",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_solicitacao_cliente_id",
                table: "cliente_solicitacao",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_solicitacao_pendencia_solicitacao_id",
                table: "cliente_solicitacao_pendencia",
                column: "solicitacao_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente_biometria_digital");

            migrationBuilder.DropTable(
                name: "cliente_solicitacao_pendencia");

            migrationBuilder.DropTable(
                name: "cliente_solicitacao");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
