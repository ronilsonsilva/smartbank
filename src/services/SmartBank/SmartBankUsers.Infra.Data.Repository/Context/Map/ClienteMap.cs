using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBank.Domain.Entities;

namespace SmartBank.Infra.Data.Repository.Context.Map
{
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

            #region [RG]

            builder.Property(x => x.Rg)
                .HasMaxLength(40)
                .HasColumnName("rg");
            
            builder.Property(x => x.RgOrgaoExpeditor)
                .HasMaxLength(40)
                .HasColumnName("rg_orgao_expedidor");

            builder.Property(x => x.RgUf)
                .HasMaxLength(2)
                .HasColumnName("rg_uf");

            #endregion

            #region [CNH]

            builder.OwnsOne(x => x.Cnh)
                .Property(x => x.Categoria)
                .HasMaxLength(40)
                .HasColumnName("cnh_categoria");
            
            builder.OwnsOne(x => x.Cnh)
                .Property(x => x.CodigoSituacao)
                .HasMaxLength(40)
                .HasColumnName("cnh_codigo_situacao");
            
            builder.OwnsOne(x => x.Cnh)
                .Property(x => x.DataPrimeiraHabilitacao)
                .HasColumnName("cnh_data_primeira_habilitacao");
            
            builder.OwnsOne(x => x.Cnh)
                .Property(x => x.DataUltimaEmissao)
                .HasColumnName("cnh_data_ultima_emissao");
            
            builder.OwnsOne(x => x.Cnh)
                .Property(x => x.DataValidade)
                .HasColumnName("cnh_data_validade");
            
            builder.OwnsOne(x => x.Cnh)
                .Property(x => x.NumeroRegistro)
                .HasColumnName("cnh_numero_registro");
            
            builder.OwnsOne(x => x.Cnh)
                .Property(x => x.RegistroNacionalEstrangeiro)
                .HasColumnName("cnh_registro_nacional_estrangeiro");


            #endregion


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

            builder.Property(x => x.RendaMensal)
                .HasColumnName("renda_mensal");

            builder.HasOne(x => x.BiometriaFacial)
                .WithOne(x => x.Cliente)
                .HasForeignKey<ClienteBiometriaFacial>(x => x.ClienteId);

            builder.HasOne(x => x.Score)
                .WithOne(x => x.Cliente)
                .HasForeignKey<ClienteScore>(x => x.ClienteId);


            builder.HasOne(x => x.ValidacaoCadastral)
                .WithOne(x => x.Cliente)
                .HasForeignKey<ClienteValidacaoCadastral>(x => x.ClienteId);


            builder.Ignore(x => x.ValidacaoBiometrica);
            builder.Ignore(x => x.ValidacaoFacial);

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

    public class ClienteValidacaoCadastralMap : BaseMap<ClienteValidacaoCadastral>
    {
        public ClienteValidacaoCadastralMap(string nomeTabela = "cliente_validacao_cadastral") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<ClienteValidacaoCadastral> builder)
        {
            builder.Property(x => x.ClienteId)
                .IsRequired()
                .HasColumnName("cliente_id");
            
            builder.Property(x => x.CpfDisponivel)
                .IsRequired()
                .HasColumnName("cpf_disponivel");
            
            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnName("data_nascimento");
            
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("nome");
            
            builder.Property(x => x.NomeSimilaridade)
                .IsRequired()
                .HasColumnName("nome_similaridade");
            
            builder.Property(x => x.SituaçãoCpf)
                .IsRequired()
                .HasColumnName("situacao_cpf");
            

            base.Configure(builder);
        }
    }
}
