using Newtonsoft.Json;

namespace SmartBank.DataValid.Api.Integrations.Models.BasicoValidarPF
{
    public class ResponseValidarPFBiometriaFacial
    {
        [JsonProperty("nome")]
        public bool Nome { get; set; }

        [JsonProperty("sexo")]
        public bool Sexo { get; set; }

        [JsonProperty("nacionalidade")]
        public bool Nacionalidade { get; set; }

        [JsonProperty("filiacao")]
        public Filiacao Filiacao { get; set; }

        [JsonProperty("cnh")]
        public Cnh Cnh { get; set; }

        [JsonProperty("documento")]
        public Documento Documento { get; set; }

        [JsonProperty("endereco")]
        public Endereco Endereco { get; set; }

        [JsonProperty("cpf_disponivel")]
        public bool CpfDisponivel { get; set; }

        [JsonProperty("nome_similaridade")]
        public int NomeSimilaridade { get; set; }

        [JsonProperty("data_nascimento")]
        public bool DataNascimento { get; set; }

        [JsonProperty("situacao_cpf")]
        public bool SituacaoCpf { get; set; }

        [JsonProperty("biometria_face")]
        public BiometriaFace BiometriaFace { get; set; }
    }
}
