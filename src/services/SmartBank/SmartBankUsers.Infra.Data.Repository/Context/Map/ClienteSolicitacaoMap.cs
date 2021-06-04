using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBank.Domain.Entities;
using System;

namespace SmartBank.Infra.Data.Repository.Context.Map
{
    public class ClienteSolicitacaoMap : BaseMap<ClienteSolicitacao>
    {
        public ClienteSolicitacaoMap(string nomeTabela = "cliente_solicitacao") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<ClienteSolicitacao> builder)
        {
            builder.Property(x => x.ClienteId)
                .IsRequired()
                .HasColumnName("cliente_id");

            builder.Property(x => x.Data)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasColumnName("data");

            builder.Property(x => x.DataAprovacao)
                .HasColumnName("data_aprovacao");

            builder.Property(x => x.DataCancelamento)
                .HasColumnName("data_cancelamento");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(StatusSolicitacao.INICIADA)
                .HasColumnName("status");

            builder.Property(x => x.Tipo)
                .IsRequired()
                .HasDefaultValue(TipoSolicitacao.EMPRESTIMO)
                .HasColumnName("tipo");

            builder.Property(x => x.ValorLiberado)
                .HasColumnName("valo_liberado");

            builder.Property(x => x.ValorSolicitado)
                .HasColumnName("valor_liberado");

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Solicitacoes)
                .HasForeignKey(x => x.ClienteId)
                .HasConstraintName("fk_cliente__cliente_solicitacoes");

            base.Configure(builder);
        }
    }
}
