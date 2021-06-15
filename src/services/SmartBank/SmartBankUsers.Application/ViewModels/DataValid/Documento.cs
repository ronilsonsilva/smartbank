using Newtonsoft.Json;

namespace SmartBank.Application.ViewModels.DataValid
{
    public class Documento
    {
        public Documento(int tipo, string numero, string orgaoExpedidor, string ufExpedidor)
        {
            Tipo = tipo;
            Numero = numero;
            OrgaoExpedidor = orgaoExpedidor;
            UfExpedidor = ufExpedidor;
        }

        [JsonProperty("tipo")]
        public int Tipo { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("orgao_expedidor")]
        public string OrgaoExpedidor { get; set; }

        [JsonProperty("uf_expedidor")]
        public string UfExpedidor { get; set; }
    }
}
