using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBank.Domain.Entities;

namespace SmartBank.Infra.Data.Repository.Context.Map
{
    public class ClienteScoreMap : BaseMap<ClienteScore>
    {
        public ClienteScoreMap(string nomeTabela = "cliente_score") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<ClienteScore> builder)
        {
            builder.Property(x => x.Score)
                .IsRequired()
                .HasColumnName("score");
            
            builder.Property(x => x.ClienteId)
                .IsRequired()
                .HasColumnName("cliente_id");

            base.Configure(builder);
        }
    }
}
