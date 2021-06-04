using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBank.Domain.Entities;

namespace SmartBank.Infra.Data.Repository.Context.Map
{
    public class ClienteBiometriaDigitalMap : BaseMap<ClienteBiometriaDigital>
    {
        public ClienteBiometriaDigitalMap(string nomeTabela = "cliente_biometria_digital") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<ClienteBiometriaDigital> builder)
        {
            builder.Property(x => x.Posicao)
                .IsRequired()
                .HasColumnName("posicao");

            builder.Property(x => x.Probabilidade)
                .HasColumnName("propabilidade");

            builder.Property(x => x.Similaridade)
                .HasColumnName("similaridade");

            builder.Property(x => x.ClienteId)
                .IsRequired()
                .HasColumnName("cliente_id");

            builder.Property(x => x.BiometriaBase64)
                .IsRequired()
                .HasColumnName("biometria_base64");

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.BiometriasDigital)
                .HasForeignKey(x => x.ClienteId)
                .HasConstraintName("fk_cliente__cliente_biometria_digital");

            builder.Ignore(x => x.Valida);
            builder.Ignore(x => x.ValidationResult);

            base.Configure(builder);
        }
    }
}
