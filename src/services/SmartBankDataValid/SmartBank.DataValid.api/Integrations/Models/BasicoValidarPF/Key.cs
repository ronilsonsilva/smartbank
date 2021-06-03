using Newtonsoft.Json;

namespace SmartBank.DataValid.Api.Integrations.Models.BasicoValidarPF
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Key
    {
        public Key(string cpf)
        {
            Cpf = cpf;
        }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }
    }
}
