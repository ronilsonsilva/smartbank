using SmartBank.DataValid.Api.Integrations.Models.BasicoValidarPF;
using System.Collections.Generic;

namespace SmartBank.DataValid.Api.Integrations.Models
{
    public class ResultadoValidacoes
    {
        public bool Valido { get; private set; }
        public IList<Validacao> Validacoes { get; private set; }
        public ValidarPessoaFisica ValidarPessoaFisica { get; private set; }
        public BiometriaDigital Biometria { get; private set; }
        public BiometriaFace BiometriaFace { get; private set; }

        public ResultadoValidacoes AdicioneResultado(bool valido)
        {
            this.Valido = valido;
            return this;
        }

        public ResultadoValidacoes AdicioneValidacao(Validacao validacao)
        {
            if (this.Validacoes == null)
                this.Validacoes = new List<Validacao>();
            this.Validacoes.Add(validacao);
            return this;
        }

        public ResultadoValidacoes AdicioneDadosValidados(ValidarPessoaFisica validarPessoaFisica)
        {
            this.ValidarPessoaFisica = validarPessoaFisica;
            return this;
        }

        public ResultadoValidacoes AdicioneResultadoBiometria(BiometriaDigital biometria)
        {
            this.Biometria = biometria;
            return this;
        }

        public ResultadoValidacoes AdicioneResultadoBiometriaFacial(BiometriaFace biometriaFace)
        {
            this.BiometriaFace = biometriaFace;
            return this;
        }
    }

    public class Validacao
    {
        public Validacao(string key, object resultado)
        {
            Key = key;
            Resultado = resultado;
        }

        public string Key { get; set; }
        public object Resultado { get; set; }
    }
}
