using Newtonsoft.Json;

namespace SmartBank.Application.ViewModels.DataValid
{
    public class Filiacao
    {
        public Filiacao(string nomeMae, string nomePai)
        {
            NomeMae = nomeMae;
            NomePai = nomePai;
        }

        [JsonProperty("nome_mae")]
        public string NomeMae { get; set; }

        [JsonProperty("nome_pai")]
        public string NomePai { get; set; }
    }
}
