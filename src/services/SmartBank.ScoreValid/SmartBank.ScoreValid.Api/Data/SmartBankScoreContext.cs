using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBank.ScoreValid.Api.Model;
using System;

namespace SmartBank.ScoreValid.Api.Data
{
    public class SmartBankScoreContext : DbContext
    {
        public SmartBankScoreContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteScoreMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class ClienteScoreMap : IEntityTypeConfiguration<ClienteScore>
    {
        public void Configure(EntityTypeBuilder<ClienteScore> builder)
        {
            builder.ToTable("cliente_score");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .HasDefaultValue(Guid.NewGuid())
                .HasColumnName("id");

            builder.Property(x => x.Data)
                .IsRequired()
                .HasColumnName("data");

            builder.Property(x => x.Score)
                .IsRequired()
                .HasColumnName("score");

            builder.Property(x => x.ClienteId)
                .IsRequired()
                .HasColumnName("cliente_id");
        }
    }
}
