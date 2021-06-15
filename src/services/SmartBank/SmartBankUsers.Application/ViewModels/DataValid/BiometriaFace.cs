using Newtonsoft.Json;

namespace SmartBank.Application.ViewModels.DataValid
{
    public class BiometriaFace
    {
        [JsonProperty("disponivel")]
        public bool Disponivel { get; set; }

        [JsonProperty("probabilidade")]
        public string Probabilidade { get; set; }

        [JsonProperty("similaridade")]
        public int Similaridade { get; set; }
    }
}
