using Newtonsoft.Json;

namespace SmartBank.Application.ViewModels.DataValid
{
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
