using Newtonsoft.Json;

namespace SmartBank.DataValid.Api.Integrations.Models.BasicoValidarPF
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
