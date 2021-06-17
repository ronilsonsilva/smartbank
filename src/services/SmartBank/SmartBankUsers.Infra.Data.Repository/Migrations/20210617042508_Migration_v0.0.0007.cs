using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBank.Infra.Data.Repository.Migrations
{
    public partial class Migration_v000007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_validacao_cadastral",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 273, DateTimeKind.Local).AddTicks(7191),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 74, DateTimeKind.Local).AddTicks(2554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_validacao_cadastral",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 273, DateTimeKind.Local).AddTicks(8412),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 74, DateTimeKind.Local).AddTicks(3407));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 315, DateTimeKind.Local).AddTicks(4463),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 116, DateTimeKind.Local).AddTicks(1591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 318, DateTimeKind.Local).AddTicks(911),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 120, DateTimeKind.Local).AddTicks(3301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 318, DateTimeKind.Local).AddTicks(1841),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 120, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 311, DateTimeKind.Local).AddTicks(9099),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 102, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 312, DateTimeKind.Local).AddTicks(225),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 102, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 304, DateTimeKind.Local).AddTicks(9440),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 96, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 320, DateTimeKind.Local).AddTicks(1432),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 124, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 320, DateTimeKind.Local).AddTicks(2214),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 124, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 299, DateTimeKind.Local).AddTicks(6090),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 91, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 299, DateTimeKind.Local).AddTicks(7404),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 92, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 293, DateTimeKind.Local).AddTicks(6836),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 87, DateTimeKind.Local).AddTicks(5772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 293, DateTimeKind.Local).AddTicks(8008),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 87, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.AlterColumn<string>(
                name: "nome_mae",
                table: "cliente",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 255, DateTimeKind.Local).AddTicks(6889),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 61, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 262, DateTimeKind.Local).AddTicks(370),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 65, DateTimeKind.Local).AddTicks(3227));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_validacao_cadastral",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 74, DateTimeKind.Local).AddTicks(2554),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 273, DateTimeKind.Local).AddTicks(7191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_validacao_cadastral",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 74, DateTimeKind.Local).AddTicks(3407),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 273, DateTimeKind.Local).AddTicks(8412));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 116, DateTimeKind.Local).AddTicks(1591),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 315, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 120, DateTimeKind.Local).AddTicks(3301),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 318, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 120, DateTimeKind.Local).AddTicks(4623),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 318, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 102, DateTimeKind.Local).AddTicks(4896),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 311, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 102, DateTimeKind.Local).AddTicks(8765),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 312, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 96, DateTimeKind.Local).AddTicks(7389),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 304, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 124, DateTimeKind.Local).AddTicks(608),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 320, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_score",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 124, DateTimeKind.Local).AddTicks(2317),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 320, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 91, DateTimeKind.Local).AddTicks(9854),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 299, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 92, DateTimeKind.Local).AddTicks(707),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 299, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 87, DateTimeKind.Local).AddTicks(5772),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 293, DateTimeKind.Local).AddTicks(6836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 87, DateTimeKind.Local).AddTicks(7689),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 293, DateTimeKind.Local).AddTicks(8008));

            migrationBuilder.AlterColumn<string>(
                name: "nome_mae",
                table: "cliente",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 61, DateTimeKind.Local).AddTicks(7054),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 255, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 0, 3, 2, 65, DateTimeKind.Local).AddTicks(3227),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 17, 1, 25, 7, 262, DateTimeKind.Local).AddTicks(370));
        }
    }
}
