using SmartBank.Domain.EntitiesValidators;
using SmartBank.Domain.ValuesObject;
using System;

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
    }
}
