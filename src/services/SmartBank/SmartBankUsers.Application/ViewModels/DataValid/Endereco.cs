using Newtonsoft.Json;

namespace SmartBank.Application.ViewModels.DataValid
{
    public class Endereco
    {
        public Endereco(string logradouro, string numero, string complemento, string bairro, string cep, string municipio, string uf)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Municipio = municipio;
            Uf = uf;
        }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("municipio")]
        public string Municipio { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }
    }
}
