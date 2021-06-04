using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBank.Infra.Data.Repository.Migrations
{
    public partial class Migration_v000002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 23, 2, 3, 579, DateTimeKind.Local).AddTicks(8320),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 18, 16, 34, 38, 735, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.CreateTable(
                name: "cliente_solicitacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    data = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 3, 23, 2, 3, 598, DateTimeKind.Local).AddTicks(2719)),
                    tipo = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    valor_liberado = table.Column<decimal>(type: "numeric", nullable: false),
                    valo_liberado = table.Column<decimal>(type: "numeric", nullable: false),
                    data_aprovacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    data_cancelamento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 3, 23, 2, 3, 609, DateTimeKind.Local).AddTicks(7422)),
                    Atualizado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                    data_pendencia = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 3, 23, 2, 3, 615, DateTimeKind.Local).AddTicks(4313)),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    data_resolvida = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    descricao = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    resolucao = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    solicitacao_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 3, 23, 2, 3, 620, DateTimeKind.Local).AddTicks(4836)),
                    Atualizado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                name: "cliente_solicitacao_pendencia");

            migrationBuilder.DropTable(
                name: "cliente_solicitacao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_atualizacao",
                table: "cliente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 18, 16, 34, 38, 735, DateTimeKind.Local).AddTicks(9427),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 6, 3, 23, 2, 3, 579, DateTimeKind.Local).AddTicks(8320));
        }
    }
}
