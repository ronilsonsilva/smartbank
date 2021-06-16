using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartBank.Application.ViewModels.DataValid
{
    public class Answer
    {
        public Answer(string nome, string sexo, int nacionalidade, Filiacao filiacao, Documento documento, Endereco endereco, Cnh cnh, string dataNascimento, string situacaoCpf)
        {
            Nome = nome;
            Sexo = sexo;
            Nacionalidade = nacionalidade;
            Filiacao = filiacao;
            Documento = documento;
            Endereco = endereco;
            Cnh = cnh;
            DataNascimento = dataNascimento;
            SituacaoCpf = situacaoCpf;
        }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("sexo")]
        public string Sexo { get; set; }

        [JsonProperty("nacionalidade")]
        public int Nacionalidade { get; set; }

        [JsonProperty("filiacao")]
        public Filiacao Filiacao { get; set; }

        [JsonProperty("documento")]
        public Documento Documento { get; set; }

        [JsonProperty("endereco")]
        public Endereco Endereco { get; set; }

        [JsonProperty("cnh")]
        public Cnh Cnh { get; set; }

        //[JsonProperty("data_nascimento")]
        public string DataNascimento { get; set; }

        //[JsonProperty("situacao_cpf")]
        public string SituacaoCpf { get; set; }

        //[JsonProperty("digitais")]
        public List<Digital> Digitais { get; set; }

        //[JsonProperty("biometria_face")]
        public string BiometriaFace { get; set; }
    }
}
