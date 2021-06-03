using Newtonsoft.Json;

namespace SmartBank.DataValid.Api.Integrations.Models.BasicoValidarPF
{
    public class ValidarPessoaFisica
    {
        public ValidarPessoaFisica(Key key, Answer answer)
        {
            Key = key;
            Answer = answer;
        }

        [JsonProperty("key")]
        public Key Key { get; set; }

        [JsonProperty("answer")]
        public Answer Answer { get; set; }
    }
}
