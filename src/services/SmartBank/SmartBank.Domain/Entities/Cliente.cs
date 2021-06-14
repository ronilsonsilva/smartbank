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
        public string Cnh { get; set; }
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
    }
}
