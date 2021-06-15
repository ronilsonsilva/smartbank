using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartBank.Application.ViewModels.DataValid
{
    public class BiometriaDigital
    {
        [JsonProperty("disponivel")]
        public bool Disponivel { get; set; }

        [JsonProperty("digitais")]
        public List<Digital> Digitais { get; set; }
    }
}
