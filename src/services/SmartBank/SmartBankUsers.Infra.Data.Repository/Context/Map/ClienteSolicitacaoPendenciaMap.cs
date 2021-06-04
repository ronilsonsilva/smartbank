using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBank.Domain.Entities;
using System;

namespace SmartBank.Infra.Data.Repository.Context.Map
{
    public class ClienteSolicitacaoPendenciaMap : BaseMap<ClienteSolicitacaoPendecia>
    {
        public ClienteSolicitacaoPendenciaMap(string nomeTabela = "cliente_solicitacao_pendencia") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<ClienteSolicitacaoPendecia> builder)
        {
            builder.Property(x => x.DataPendencia)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnName("data_pendencia");

            builder.Property(x => x.DataResolvida)
                .HasColumnName("data_resolvida");

            builder.Property(x => x.Descricao)
                .HasMaxLength(4096)
                .HasColumnName("descricao");

            builder.Property(x => x.Resolucao)
                .HasMaxLength(4096)
                .HasColumnName("resolucao");

            builder.Property(x => x.SolicitacaoId)
                .IsRequired()
                .HasColumnName("solicitacao_id");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(StatusPendenciaSolicitacao.PENDENTE)
                .HasColumnName("status");

            builder.Property(x => x.Tipo)
                .IsRequired()
                .HasDefaultValue(TipoPedencia.DOCUMENTOS_INVALIDO)
                .HasColumnName("tipo");

            builder.HasOne(x => x.Solicitacao)
                .WithMany(x => x.Pendencias)
                .HasForeignKey(x => x.SolicitacaoId)
                .HasConstraintName("fk_solicitacao__pendencia_solicitacao");

            base.Configure(builder);
        }
    }
}
