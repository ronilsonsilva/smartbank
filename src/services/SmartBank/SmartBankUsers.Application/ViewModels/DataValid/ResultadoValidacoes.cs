using System.Collections.Generic;

namespace SmartBank.Application.ViewModels.DataValid
{
    public class ResultadoValidacoes
    {
        public bool Valido { get; private set; }
        public IList<Validacao> Validacoes { get; set; }
        public ValidarPessoaFisica ValidarPessoaFisica { get; set; }
        public BiometriaDigital Biometria { get; set; }
        public BiometriaFace BiometriaFace { get; set; }

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
}
