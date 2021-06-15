using Newtonsoft.Json;

namespace SmartBank.Application.ViewModels.DataValid
{
    public class Cnh
    {
        public Cnh(string categoria, string numeroRegistro, string dataPrimeiraHabilitacao, string dataValidade, string registroNacionalEstrangeiro, string dataUltimaEmissao, string codigoSituacao)
        {
            Categoria = categoria;
            NumeroRegistro = numeroRegistro;
            DataPrimeiraHabilitacao = dataPrimeiraHabilitacao;
            DataValidade = dataValidade;
            RegistroNacionalEstrangeiro = registroNacionalEstrangeiro;
            DataUltimaEmissao = dataUltimaEmissao;
            CodigoSituacao = codigoSituacao;
        }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }

        [JsonProperty("numero_registro")]
        public string NumeroRegistro { get; set; }

        [JsonProperty("data_primeira_habilitacao")]
        public string DataPrimeiraHabilitacao { get; set; }

        [JsonProperty("data_validade")]
        public string DataValidade { get; set; }

        [JsonProperty("registro_nacional_estrangeiro")]
        public string RegistroNacionalEstrangeiro { get; set; }

        [JsonProperty("data_ultima_emissao")]
        public string DataUltimaEmissao { get; set; }

        [JsonProperty("codigo_situacao")]
        public string CodigoSituacao { get; set; }
    }
}
