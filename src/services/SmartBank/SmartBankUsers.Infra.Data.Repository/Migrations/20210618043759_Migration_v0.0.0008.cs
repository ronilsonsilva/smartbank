using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBank.Infra.Data.Repository.Migrations
{
    public partial class Migration_v000008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_validacao_cadastral",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 94, DateTimeKind.Local).AddTicks(1764),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 273, DateTimeKind.Local).AddTicks(7191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_validacao_cadastral",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 94, DateTimeKind.Local).AddTicks(2574),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 273, DateTimeKind.Local).AddTicks(8412));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 118, DateTimeKind.Local).AddTicks(6090),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 315, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 121, DateTimeKind.Local).AddTicks(3322),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 318, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 121, DateTimeKind.Local).AddTicks(4228),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 318, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 114, DateTimeKind.Local).AddTicks(7940),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 311, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 114, DateTimeKind.Local).AddTicks(9161),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 312, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 111, DateTimeKind.Local).AddTicks(9514),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 304, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 123, DateTimeKind.Local).AddTicks(3926),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 320, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 123, DateTimeKind.Local).AddTicks(4695),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 320, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 107, DateTimeKind.Local).AddTicks(8179),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 299, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 107, DateTimeKind.Local).AddTicks(8950),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 299, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 104, DateTimeKind.Local).AddTicks(8189),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 293, DateTimeKind.Local).AddTicks(6836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 104, DateTimeKind.Local).AddTicks(9288),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 293, DateTimeKind.Local).AddTicks(8008));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 85, DateTimeKind.Local).AddTicks(4301),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 255, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 87, DateTimeKind.Local).AddTicks(9484),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 262, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.AddColumn<string>(
                name: "codigo_redefinicao_senha",
                table: "cliente",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "validade_codigo_redefinicao_senha",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigo_redefinicao_senha",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "validade_codigo_redefinicao_senha",
                table: "cliente");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_validacao_cadastral",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 273, DateTimeKind.Local).AddTicks(7191),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 94, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_validacao_cadastral",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 273, DateTimeKind.Local).AddTicks(8412),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 94, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 315, DateTimeKind.Local).AddTicks(4463),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 118, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 318, DateTimeKind.Local).AddTicks(911),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 121, DateTimeKind.Local).AddTicks(3322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 318, DateTimeKind.Local).AddTicks(1841),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 121, DateTimeKind.Local).AddTicks(4228));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 311, DateTimeKind.Local).AddTicks(9099),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 114, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 312, DateTimeKind.Local).AddTicks(225),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 114, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 304, DateTimeKind.Local).AddTicks(9440),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 111, DateTimeKind.Local).AddTicks(9514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 320, DateTimeKind.Local).AddTicks(1432),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 123, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 320, DateTimeKind.Local).AddTicks(2214),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 123, DateTimeKind.Local).AddTicks(4695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 299, DateTimeKind.Local).AddTicks(6090),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 107, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 299, DateTimeKind.Local).AddTicks(7404),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 107, DateTimeKind.Local).AddTicks(8950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 293, DateTimeKind.Local).AddTicks(6836),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 104, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 293, DateTimeKind.Local).AddTicks(8008),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 104, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 255, DateTimeKind.Local).AddTicks(6889),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 85, DateTimeKind.Local).AddTicks(4301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 262, DateTimeKind.Local).AddTicks(370),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 18, 1, 37, 58, 87, DateTimeKind.Local).AddTicks(9484));
        }
    }
}
