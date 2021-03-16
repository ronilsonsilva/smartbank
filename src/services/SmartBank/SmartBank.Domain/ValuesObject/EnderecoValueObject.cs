namespace SmartBank.Domain.ValuesObject
{
    public class EnderecoValueObject
    {
        public EnderecoValueObject() { }

        public EnderecoValueObject(string cep, string logradouro, string complemento, string numero, string bairro, string cidade, int codigoIBGE)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            CodigoIBGE = codigoIBGE;
        }

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int CodigoIBGE { get; set; }
    }
}
