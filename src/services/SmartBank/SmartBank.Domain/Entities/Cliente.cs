using SmartBank.Domain.EntitiesValidators;
using SmartBank.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBank.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public Cliente()
        {
            Validate(this, new ClienteValidator());
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string RgOrgaoExpeditor { get; set; }
        public string RgUf { get; set; }
        public CnhValueObject Cnh { get; set; }
        public DateTime DataNascimento { get; set; }
        public SexoPessoa Sexo { get; set; }
        public ContatoValueObject Contato { get; set; }
        public EnderecoValueObject Endereco { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public GrauEscolaridade Escolaridade { get; set; }
        public ClienteEmpresaValueObject EmpresaTrabalho { get; set; }
        public string Usuario { get; set; }
        public decimal RendaMensal { get; set; }
        public IList<ClienteSolicitacao> Solicitacoes { get; set; }
        public IList<ClienteBiometriaDigital> BiometriasDigital { get; set; }
        public ClienteBiometriaFacial BiometriaFacial { get; set; }
        public ClienteScore Score { get; set; }
        public ClienteValidacaoCadastral ValidacaoCadastral { get; set; }
        public bool ValidacaoBiometrica
        {
            get
            {
                return this.BiometriasDigital?.Where(x => x.Valida)?.Count() > 0;
            }
        }

        public bool ValidacaoFacial
        {
            get
            {
                return this.BiometriaFacial?.Valida == true;
            }
        }

        public bool CadastroValidado
        {
            get
            {
                return this.ValidacaoCadastral?.CpfDisponivel == true 
                    && this.ValidacaoCadastral?.Nome == true 
                    && this.ValidacaoCadastral?.NomeSimilaridade == true 
                    && this.ValidacaoCadastral?.SituaçãoCpf == true;
            }
        }
    }

    public class ClienteValidacaoCadastral : EntityBase
    {
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public bool Nome { get; set; }
        public bool CpfDisponivel { get; set; }
        public bool NomeSimilaridade { get; set; }
        public bool DataNascimento { get; set; }
        public bool SituaçãoCpf { get; set; }
    }
}
