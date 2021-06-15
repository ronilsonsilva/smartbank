using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBank.Infra.Data.Repository.Migrations
{
    public partial class Migration_v000006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cnh",
                table: "cliente",
                newName: "rg_orgao_expedidor");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 116, DateTimeKind.Local).AddTicks(1591),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 726, DateTimeKind.Local).AddTicks(8146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 120, DateTimeKind.Local).AddTicks(3301),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 730, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 120, DateTimeKind.Local).AddTicks(4623),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 730, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 102, DateTimeKind.Local).AddTicks(4896),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 720, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 102, DateTimeKind.Local).AddTicks(8765),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 720, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 96, DateTimeKind.Local).AddTicks(7389),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 715, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 124, DateTimeKind.Local).AddTicks(608),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 733, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 124, DateTimeKind.Local).AddTicks(2317),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 734, DateTimeKind.Local).AddTicks(414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 91, DateTimeKind.Local).AddTicks(9854),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 708, DateTimeKind.Local).AddTicks(8320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 92, DateTimeKind.Local).AddTicks(707),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 709, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 87, DateTimeKind.Local).AddTicks(5772),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 704, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 87, DateTimeKind.Local).AddTicks(7689),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 704, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 61, DateTimeKind.Local).AddTicks(7054),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 681, DateTimeKind.Local).AddTicks(9849));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 65, DateTimeKind.Local).AddTicks(3227),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 685, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.AddColumn<string>(
                name: "EmpresaTrabalho_Endereco_Uf",
                table: "cliente",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Uf",
                table: "cliente",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cnh_categoria",
                table: "cliente",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cnh_codigo_situacao",
                table: "cliente",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "cnh_data_primeira_habilitacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "cnh_data_ultima_emissao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "cnh_data_validade",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cnh_numero_registro",
                table: "cliente",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cnh_registro_nacional_estrangeiro",
                table: "cliente",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rg_uf",
                table: "cliente",
                type: "character varying(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cliente_validacao_cadastral",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<bool>(type: "boolean", nullable: false),
                    cpf_disponivel = table.Column<bool>(type: "boolean", nullable: false),
                    nome_similaridade = table.Column<bool>(type: "boolean", nullable: false),
                    data_nascimento = table.Column<bool>(type: "boolean", nullable: false),
                    situacao_cpf = table.Column<bool>(type: "boolean", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 74, DateTimeKind.Local).AddTicks(2554)),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 74, DateTimeKind.Local).AddTicks(3407))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_validacao_cadastral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cliente_validacao_cadastral_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_validacao_cadastral_cliente_id",
                table: "cliente_validacao_cadastral",
                column: "cliente_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente_validacao_cadastral");

            migrationBuilder.DropColumn(
                name: "EmpresaTrabalho_Endereco_Uf",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "Endereco_Uf",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "cnh_categoria",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "cnh_codigo_situacao",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "cnh_data_primeira_habilitacao",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "cnh_data_ultima_emissao",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "cnh_data_validade",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "cnh_numero_registro",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "cnh_registro_nacional_estrangeiro",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "rg_uf",
                table: "cliente");

            migrationBuilder.RenameColumn(
                name: "rg_orgao_expedidor",
                table: "cliente",
                newName: "cnh");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 726, DateTimeKind.Local).AddTicks(8146),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 116, DateTimeKind.Local).AddTicks(1591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 730, DateTimeKind.Local).AddTicks(7284),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 120, DateTimeKind.Local).AddTicks(3301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 730, DateTimeKind.Local).AddTicks(8673),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 120, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 720, DateTimeKind.Local).AddTicks(2588),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 102, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 720, DateTimeKind.Local).AddTicks(3848),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 102, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 715, DateTimeKind.Local).AddTicks(7707),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 96, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 733, DateTimeKind.Local).AddTicks(9054),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 124, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 734, DateTimeKind.Local).AddTicks(414),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 124, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 708, DateTimeKind.Local).AddTicks(8320),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 91, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 709, DateTimeKind.Local).AddTicks(59),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 92, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 704, DateTimeKind.Local).AddTicks(1465),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 87, DateTimeKind.Local).AddTicks(5772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 704, DateTimeKind.Local).AddTicks(2477),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 87, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 681, DateTimeKind.Local).AddTicks(9849),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 61, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 685, DateTimeKind.Local).AddTicks(3057),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 65, DateTimeKind.Local).AddTicks(3227));
        }
    }
}
