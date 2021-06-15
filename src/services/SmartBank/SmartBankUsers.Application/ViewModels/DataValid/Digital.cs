using Newtonsoft.Json;

namespace SmartBank.Application.ViewModels.DataValid
{
    public class Digital
    {
        [JsonProperty("posicao")]
        public int Posicao { get; set; }

        [JsonProperty("formato")]
        public string Formato { get; set; }

        [JsonProperty("imagem")]
        public string Imagem { get; set; }
    }
}
