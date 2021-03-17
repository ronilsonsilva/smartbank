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

    public class ClienteMap : BaseMap<Cliente>
    {
        public ClienteMap(string nomeTabela = "cliente") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("cpf");

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnName("data_nascimento");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("nome");
            
            builder.Property(x => x.NomeMae)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("nome_mae");
            
            builder.Property(x => x.NomePai)
                .HasMaxLength(256)
                .HasColumnName("nome_pai");
            
            builder.Property(x => x.Sexo)
                .IsRequired()
                .HasColumnName("sexo");
            
            builder.Property(x => x.Escolaridade)
                .HasColumnName("escolaridade");
            
            builder.Property(x => x.Rg)
                .HasMaxLength(40)
                .HasColumnName("rg");
            
            builder.Property(x => x.Cnh)
                .HasMaxLength(40)
                .HasColumnName("cnh");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .Property(x => x.Cnpj)
                .HasMaxLength(20)
                .HasColumnName("empresa_trabalho_cnpj");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .Property(x => x.NomeFantasia)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_nome_fantasia");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .Property(x => x.RazaoSocial)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_razao_social");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .OwnsOne(x => x.Contato)
                .Property(x => x.Email)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_email");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .OwnsOne(x => x.Contato)
                .Property(x => x.TelefoneCelular)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_celular");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .OwnsOne(x => x.Contato)
                .Property(x => x.TelefoneFixo)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_telefone");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .OwnsOne(x => x.Endereco)
                .Property(x => x.Bairro)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_bairro");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .OwnsOne(x => x.Endereco)
                .Property(x => x.Cep)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_cep");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .OwnsOne(x => x.Endereco)
                .Property(x => x.Cidade)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_cidade");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .OwnsOne(x => x.Endereco)
                .Property(x => x.CodigoIBGE)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_cidade_ibge");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .OwnsOne(x => x.Endereco)
                .Property(x => x.Complemento)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_endereco_complemento");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .OwnsOne(x => x.Endereco)
                .Property(x => x.Logradouro)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_endereco_logradouro");
            
            builder.OwnsOne(x => x.EmpresaTrabalho)
                .OwnsOne(x => x.Endereco)
                .Property(x => x.Numero)
                .HasMaxLength(256)
                .HasColumnName("empresa_trabalho_endereco_numero");
            
            #region [Endereco]

            builder.OwnsOne(x => x.Contato)
                .Property(x => x.TelefoneCelular)
                .HasMaxLength(20)
                .HasColumnName("telelefone_celular");

            builder.OwnsOne(x => x.Contato)
                .Property(x => x.Email)
                .HasMaxLength(256)
                .HasColumnName("email");

            builder.OwnsOne(x => x.Contato)
                .Property(x => x.TelefoneFixo)
                .HasMaxLength(20)
                .HasColumnName("telefone_fixo");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Bairro)
                .HasMaxLength(128)
                .HasColumnName("endereco_bairro");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Cep)
                .HasMaxLength(8)
                .HasColumnName("endereco_cep");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Cidade)
                .HasMaxLength(128)
                .HasColumnName("endereco_cidade");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.CodigoIBGE)
                .HasColumnName("cidade_codigo_ibge");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Complemento)
                .HasMaxLength(256)
                .HasColumnName("endreco_complemento");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Logradouro)
                .HasMaxLength(256)
                .HasColumnName("endreco_logradouro");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Numero)
                .HasMaxLength(8)
                .HasColumnName("endreco_numero");
            #endregion

            builder.Property(x => x.Usuario)
                .IsRequired()
                .HasMaxLength(256);

            base.Configure(builder);
        }
    }
}
