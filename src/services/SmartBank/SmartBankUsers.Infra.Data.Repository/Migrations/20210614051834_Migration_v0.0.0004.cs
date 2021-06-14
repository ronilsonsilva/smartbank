using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBank.Infra.Data.Repository.Migrations
{
    public partial class Migration_v000004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 364, DateTimeKind.Local).AddTicks(5473),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 988, DateTimeKind.Local).AddTicks(3235));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 369, DateTimeKind.Local).AddTicks(1284),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 992, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 369, DateTimeKind.Local).AddTicks(2546),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 992, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 358, DateTimeKind.Local).AddTicks(9348),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 982, DateTimeKind.Local).AddTicks(4705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 359, DateTimeKind.Local).AddTicks(84),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 982, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 355, DateTimeKind.Local).AddTicks(2178),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 977, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 348, DateTimeKind.Local).AddTicks(8313),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 970, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 348, DateTimeKind.Local).AddTicks(9839),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 970, DateTimeKind.Local).AddTicks(3589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 345, DateTimeKind.Local).AddTicks(1889),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 960, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 345, DateTimeKind.Local).AddTicks(2765),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 960, DateTimeKind.Local).AddTicks(8807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 326, DateTimeKind.Local).AddTicks(4830),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 906, DateTimeKind.Local).AddTicks(4421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 328, DateTimeKind.Local).AddTicks(9428),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 909, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.AddColumn<decimal>(
                name: "renda_mensal",
                table: "cliente",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "renda_mensal",
                table: "cliente");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 988, DateTimeKind.Local).AddTicks(3235),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 364, DateTimeKind.Local).AddTicks(5473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 992, DateTimeKind.Local).AddTicks(7847),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 369, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 992, DateTimeKind.Local).AddTicks(9179),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 369, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 982, DateTimeKind.Local).AddTicks(4705),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 358, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 982, DateTimeKind.Local).AddTicks(6016),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 359, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 977, DateTimeKind.Local).AddTicks(290),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 355, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 970, DateTimeKind.Local).AddTicks(2126),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 348, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 970, DateTimeKind.Local).AddTicks(3589),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 348, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 960, DateTimeKind.Local).AddTicks(5109),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 345, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 960, DateTimeKind.Local).AddTicks(8807),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 345, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 906, DateTimeKind.Local).AddTicks(4421),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 326, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 909, DateTimeKind.Local).AddTicks(843),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 328, DateTimeKind.Local).AddTicks(9428));
        }
    }
}
