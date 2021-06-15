using System;

namespace SmartBank.Domain.ValuesObject
{
    public class EnderecoValueObject
    {
        public EnderecoValueObject() { }

        public EnderecoValueObject(string cep, string logradouro, string complemento, string numero, string bairro, string cidade, int codigoIBGE, string uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            CodigoIBGE = codigoIBGE;
            Uf = uf;
        }

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int CodigoIBGE { get; set; }
    }

    public class CnhValueObject
    {
        public string Categoria { get; set; }

        public string NumeroRegistro { get; set; }

        public DateTime? DataPrimeiraHabilitacao { get; set; }

        public DateTime? DataValidade { get; set; }

        public string RegistroNacionalEstrangeiro { get; set; }

        public DateTime? DataUltimaEmissao { get; set; }

        public string CodigoSituacao { get; set; }
    }
}
