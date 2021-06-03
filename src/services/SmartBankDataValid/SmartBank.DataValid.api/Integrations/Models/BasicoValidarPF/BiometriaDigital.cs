using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartBank.DataValid.Api.Integrations.Models.BasicoValidarPF
{
    public class BiometriaDigital
    {
        [JsonProperty("disponivel")]
        public bool Disponivel { get; set; }

        [JsonProperty("digitais")]
        public List<Digital> Digitais { get; set; }
    }
}
