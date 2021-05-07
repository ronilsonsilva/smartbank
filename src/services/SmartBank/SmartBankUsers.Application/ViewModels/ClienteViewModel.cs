using SmartBank.Domain.ValuesObject;
using System;

namespace SmartBank.Application.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cnh { get; set; }
        public DateTime? DataNascimento { get; set; }
        public SexoPessoa? Sexo { get; set; }
        public ContatoValueObject Contato { get; set; }
        public EnderecoValueObject Endereco { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public GrauEscolaridade? Escolaridade { get; set; }
        public ClienteEmpresaValueObject EmpresaTrabalho { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
