using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBank.Domain.Entities;
using System;

namespace SmartBank.Infra.Data.Repository.Context.Map
{
    public class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        protected readonly string _nomeTabela;
        public BaseMap(string nomeTabela)
        {
            this._nomeTabela = nomeTabela;
        }
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(this._nomeTabela);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cadastro)
                .HasColumnName("data_cadastro")
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Cadastro)
                .HasColumnName("data_atualizacao")
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Ignore(x => x.Invalid);
            builder.Ignore(x => x.Valid);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
