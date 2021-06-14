using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBank.Infra.Data.Repository.Migrations
{
    public partial class Migration_v000003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 988, DateTimeKind.Local).AddTicks(3235),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 467, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 992, DateTimeKind.Local).AddTicks(7847),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 470, DateTimeKind.Local).AddTicks(60));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 992, DateTimeKind.Local).AddTicks(9179),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 470, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 982, DateTimeKind.Local).AddTicks(4705),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 458, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 982, DateTimeKind.Local).AddTicks(6016),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 458, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 977, DateTimeKind.Local).AddTicks(290),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 453, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 960, DateTimeKind.Local).AddTicks(5109),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 446, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 960, DateTimeKind.Local).AddTicks(8807),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 446, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 906, DateTimeKind.Local).AddTicks(4421),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 413, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 909, DateTimeKind.Local).AddTicks(843),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 415, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.CreateTable(
                name: "cliente_biometria_facial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_base64 = table.Column<string>(type: "text", nullable: false),
                    similaridade = table.Column<int>(type: "integer", nullable: false),
                    propabilidade = table.Column<string>(type: "text", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 970, DateTimeKind.Local).AddTicks(2126)),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 970, DateTimeKind.Local).AddTicks(3589))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_biometria_facial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cliente_biometria_facial_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_biometria_facial_cliente_id",
                table: "cliente_biometria_facial",
                column: "cliente_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente_biometria_facial");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 467, DateTimeKind.Local).AddTicks(285),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 988, DateTimeKind.Local).AddTicks(3235));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 470, DateTimeKind.Local).AddTicks(60),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 992, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 470, DateTimeKind.Local).AddTicks(698),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 992, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 458, DateTimeKind.Local).AddTicks(1498),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 982, DateTimeKind.Local).AddTicks(4705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 458, DateTimeKind.Local).AddTicks(2448),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 982, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 453, DateTimeKind.Local).AddTicks(7389),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 977, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 446, DateTimeKind.Local).AddTicks(7861),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 960, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 446, DateTimeKind.Local).AddTicks(9288),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 960, DateTimeKind.Local).AddTicks(8807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 413, DateTimeKind.Local).AddTicks(66),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 906, DateTimeKind.Local).AddTicks(4421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 12, 2, 33, 37, 415, DateTimeKind.Local).AddTicks(8890),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 1, 1, 26, 909, DateTimeKind.Local).AddTicks(843));
        }
    }
}
