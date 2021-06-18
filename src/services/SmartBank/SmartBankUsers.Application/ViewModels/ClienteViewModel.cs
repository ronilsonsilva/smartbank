using Newtonsoft.Json;
using SmartBank.Domain.ValuesObject;
using System;
using System.Collections.Generic;

namespace SmartBank.Application.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string RgOrgaoExpeditor { get; set; }
        public string RgUf { get; set; }

        public CnhValueObject Cnh { get; set; }
        public DateTime? DataNascimento { get; set; }
        public SexoPessoa? Sexo { get; set; }
        public ContatoValueObject Contato { get; set; }
        public EnderecoValueObject Endereco { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public GrauEscolaridade? Escolaridade { get; set; }
        public ClienteEmpresaValueObject EmpresaTrabalho { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public IList<ClienteSolicitacaoViewModel> Solicitacoes { get; set; }
        public bool ValidacaoBiometrica { get; set; }
        public bool CadastroValidado { get; set; }
        public bool ValidacaoFacial { get; set; }
        public decimal RendaMensal { get; set; }
        public ClienteScoreViewModel Score { get; set; }
        public ClienteValidacaoCadastralViewModel ValidacaoCadastral { get; set; }
        public ClienteBiometriaFacialViewModel BiometriaFacial { get; set; }

        public int PontoScore 
        {
            get
            {
                return this.Score != null ? this.Score.Score : 0;
            }
        }

        public string SimilaridadeBiometriaFacial 
        { 
            get
            {
                return string.IsNullOrEmpty(this.BiometriaFacial?.Probabilidade) ? "Não Realizada" : this.BiometriaFacial?.Probabilidade;
            }
        }

        public bool ValidacaoNome 
        { 
            get
            {
                return this.ValidacaoCadastral != null ? this.ValidacaoCadastral.Nome : false;
            }
        }
        public bool CpfDisponivel 
        { 
            get
            {
                return this.ValidacaoCadastral != null ? this.ValidacaoCadastral.CpfDisponivel : false;
            }
        }
        public bool NomeSimilaridade 
        {
            get
            {
                return this.ValidacaoCadastral != null ? this.ValidacaoCadastral.NomeSimilaridade : false;
            }
        }
        
        public bool SituacaoCpf 
        {
            get
            {
                return this.ValidacaoCadastral != null ? this.ValidacaoCadastral.SituaçãoCpf : false;
            }
        }

        public string CodigoRedefinicaoSenha { get; set; }
        public DateTime? ValidadeCodigoRedefinicaoSenha { get; set; }
    }

    public class RedefinirSenhaViewModel
    {
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
        public string Codigo { get; set; }
    }

    public class EnviarEmailViewModel
    {
        public EnviarEmailViewModel()
        {

        }

        public EnviarEmailViewModel(string nomeDestinatario, string emailRemetente, string mensagem, string emailDestinatario, string nomeRemetente)
        {
            NomeDestinatario = nomeDestinatario;
            EmailRemetente = emailRemetente;
            Mensagem = mensagem;
            EmailDestinatario = emailDestinatario;
            NomeRemetente = nomeRemetente;
        }

        [JsonProperty("nomeDestinatario")]
        public string NomeDestinatario { get; set; }

        [JsonProperty("emailRemetente")]
        public string EmailRemetente { get; set; }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }

        [JsonProperty("emailDestinatario")]
        public string EmailDestinatario { get; set; }

        [JsonProperty("nomeRemetente")]
        public string NomeRemetente { get; set; }
    }
}
