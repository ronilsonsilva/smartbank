using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBank.Domain.Entities;

namespace SmartBank.Infra.Data.Repository.Context.Map
{
    public class ClienteBiometriaFacialMap : BaseMap<ClienteBiometriaFacial>
    {
        public ClienteBiometriaFacialMap(string nomeTabela = "cliente_biometria_facial") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<ClienteBiometriaFacial> builder)
        {
            builder.Property(x => x.Probabilidade)
                .HasColumnName("propabilidade");

            builder.Property(x => x.Similaridade)
                .HasColumnName("similaridade");

            builder.Property(x => x.ClienteId)
                .IsRequired()
                .HasColumnName("cliente_id");

            builder.Property(x => x.ImageBase64)
                .IsRequired()
                .HasColumnName("image_base64");

            builder.Ignore(x => x.Valida);

            base.Configure(builder);
        }
    }
}
