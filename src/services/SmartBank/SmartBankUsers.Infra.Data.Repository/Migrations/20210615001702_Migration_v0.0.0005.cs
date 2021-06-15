using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBank.Infra.Data.Repository.Migrations
{
    public partial class Migration_v000005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 726, DateTimeKind.Local).AddTicks(8146),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 364, DateTimeKind.Local).AddTicks(5473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 730, DateTimeKind.Local).AddTicks(7284),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 369, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 730, DateTimeKind.Local).AddTicks(8673),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 369, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 720, DateTimeKind.Local).AddTicks(2588),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 358, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 720, DateTimeKind.Local).AddTicks(3848),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 359, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 715, DateTimeKind.Local).AddTicks(7707),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 355, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 708, DateTimeKind.Local).AddTicks(8320),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 348, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 709, DateTimeKind.Local).AddTicks(59),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 348, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 704, DateTimeKind.Local).AddTicks(1465),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 345, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 704, DateTimeKind.Local).AddTicks(2477),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 345, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 681, DateTimeKind.Local).AddTicks(9849),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 326, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 685, DateTimeKind.Local).AddTicks(3057),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 328, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.CreateTable(
                name: "cliente_score",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 733, DateTimeKind.Local).AddTicks(9054)),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 734, DateTimeKind.Local).AddTicks(414))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cliente_score_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_score_cliente_id",
                table: "cliente_score",
                column: "cliente_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente_score");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_pendencia",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 364, DateTimeKind.Local).AddTicks(5473),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 726, DateTimeKind.Local).AddTicks(8146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 369, DateTimeKind.Local).AddTicks(1284),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 730, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao_pendencia",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 369, DateTimeKind.Local).AddTicks(2546),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 730, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 358, DateTimeKind.Local).AddTicks(9348),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 720, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 359, DateTimeKind.Local).AddTicks(84),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 720, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cliente_solicitacao",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 355, DateTimeKind.Local).AddTicks(2178),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 715, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 348, DateTimeKind.Local).AddTicks(8313),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 708, DateTimeKind.Local).AddTicks(8320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_facial",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 348, DateTimeKind.Local).AddTicks(9839),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 709, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 345, DateTimeKind.Local).AddTicks(1889),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 704, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente_biometria_digital",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 345, DateTimeKind.Local).AddTicks(2765),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 704, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_cadastro",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 326, DateTimeKind.Local).AddTicks(4830),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 681, DateTimeKind.Local).AddTicks(9849));

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 2, 18, 33, 328, DateTimeKind.Local).AddTicks(9428),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 17, 0, 685, DateTimeKind.Local).AddTicks(3057));
        }
    }
}
