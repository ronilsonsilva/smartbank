using Newtonsoft.Json;
using RestSharp;
using SmartBank.DataValid.Api.Configurations;
using SmartBank.DataValid.Api.Integrations.Models;
using SmartBank.DataValid.Api.Integrations.Models.BasicoValidarPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank.DataValid.Api.Integrations
{
    public interface IDataValidIntegrationServices
    {
        Task<ResultadoValidacoes> BasicaPessoaFisica(ValidarPessoaFisica dados);
        Task<ResultadoValidacoes> DigitalPessoaFisica(ValidarPessoaFisica dados);
        Task<ResultadoValidacoes> BiometriaFacial(ValidarBiometriaFacialPessoaFisica dados);
        Task<ResultadoValidacoes> ValidacaoImagem(ValidarPessoaFisica dados);
    }

    public class DataValidIntegrationServices : IDataValidIntegrationServices
    {
        protected TokenResponse _token;
        protected DataValidConfig _dataValidConfig;

        public DataValidIntegrationServices(DataValidConfig dataValidConfig)
        {
            _dataValidConfig = dataValidConfig;
            _= this.Autentique().Result;
        }

        public async Task<ResultadoValidacoes> BasicaPessoaFisica(ValidarPessoaFisica dados)
        {
            ResultadoValidacoes resultado = new ResultadoValidacoes()
                .AdicioneResultado(false)
                .AdicioneDadosValidados(dados);

            var client = new RestClient($"{this._dataValidConfig.UriBase}/datavalid/v2/validate/pf");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {this._token.AccessToken}");
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(dados);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var validacoes = JsonConvert.DeserializeObject<ResponseValidarPF>(response.Content);
                resultado.AdicioneResultado(validacoes.Nome && validacoes.NomeSimilaridade == 1 && validacoes.CpfDisponivel && validacoes.DataNascimento);
                resultado.AdicioneValidacao(new Validacao("nome", validacoes.Nome));
                resultado.AdicioneValidacao(new Validacao("cpf_disponivel", validacoes.CpfDisponivel));
                resultado.AdicioneValidacao(new Validacao("nome_similaridade", validacoes.NomeSimilaridade));
                resultado.AdicioneValidacao(new Validacao("data_nascimento", validacoes.DataNascimento));
                resultado.AdicioneValidacao(new Validacao("situacao_cpf", validacoes.SituacaoCpf));
            }

            return resultado;
        }

        public async Task<ResultadoValidacoes> BiometriaFacial(ValidarBiometriaFacialPessoaFisica dados)
        {
            ResultadoValidacoes resultado = new ResultadoValidacoes()
                .AdicioneResultado(false)
                .AdicioneDadosValidados(dados);

            var client = new RestClient($"{this._dataValidConfig.UriBase}/datavalid/v2/validate/pf-digitais");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {this._token.AccessToken}");
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(dados);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var validacoes = JsonConvert.DeserializeObject<ResponseValidarPFBiometriaFacial>(response.Content);
                resultado.AdicioneResultado(validacoes.Nome && validacoes.NomeSimilaridade == 1 && validacoes.CpfDisponivel && validacoes.DataNascimento);
                resultado.AdicioneValidacao(new Validacao("nome", validacoes.Nome));
                resultado.AdicioneValidacao(new Validacao("cpf_disponivel", validacoes.CpfDisponivel));
                resultado.AdicioneValidacao(new Validacao("nome_similaridade", validacoes.NomeSimilaridade));
                resultado.AdicioneValidacao(new Validacao("data_nascimento", validacoes.DataNascimento));
                resultado.AdicioneValidacao(new Validacao("situacao_cpf", validacoes.SituacaoCpf));
                resultado.AdicioneResultadoBiometriaFacial(validacoes.BiometriaFace);
            }

            return resultado;
        }

        public async Task<ResultadoValidacoes> DigitalPessoaFisica(ValidarPessoaFisica dados)
        {
            ResultadoValidacoes resultado = new ResultadoValidacoes()
                .AdicioneResultado(false)
                .AdicioneDadosValidados(dados);

            var client = new RestClient($"{this._dataValidConfig.UriBase}/datavalid/v2/validate/pf-digitais");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {this._token.AccessToken}");
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(dados);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var validacoes = JsonConvert.DeserializeObject<ResponseValidarPFDigital>(response.Content);
                resultado.AdicioneResultado(validacoes.Nome && validacoes.NomeSimilaridade == 1 && validacoes.CpfDisponivel && validacoes.DataNascimento);
                resultado.AdicioneValidacao(new Validacao("nome", validacoes.Nome));
                resultado.AdicioneValidacao(new Validacao("cpf_disponivel", validacoes.CpfDisponivel));
                resultado.AdicioneValidacao(new Validacao("nome_similaridade", validacoes.NomeSimilaridade));
                resultado.AdicioneValidacao(new Validacao("data_nascimento", validacoes.DataNascimento));
                resultado.AdicioneValidacao(new Validacao("situacao_cpf", validacoes.SituacaoCpf));
                resultado.AdicioneResultadoBiometria(validacoes.BiometriaDigital);
            }

            return resultado;
        }

        public async Task<ResultadoValidacoes> ValidacaoImagem(ValidarPessoaFisica dados)
        {
            ResultadoValidacoes resultado = new ResultadoValidacoes()
                .AdicioneResultado(false)
                .AdicioneDadosValidados(dados);

            var client = new RestClient($"{this._dataValidConfig.UriBase}/datavalid/v2/validate/pf-imagem");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {this._token.AccessToken}");
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(dados);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var validacoes = JsonConvert.DeserializeObject<ResponseValidarPFImagem>(response.Content);
                resultado.AdicioneResultado(validacoes.Nome && validacoes.NomeSimilaridade == 1 && validacoes.CpfDisponivel && validacoes.DataNascimento);
                resultado.AdicioneValidacao(new Validacao("nome", validacoes.Nome));
                resultado.AdicioneValidacao(new Validacao("cpf_disponivel", validacoes.CpfDisponivel));
                resultado.AdicioneValidacao(new Validacao("nome_similaridade", validacoes.NomeSimilaridade));
                resultado.AdicioneValidacao(new Validacao("data_nascimento", validacoes.DataNascimento));
                resultado.AdicioneValidacao(new Validacao("situacao_cpf", validacoes.SituacaoCpf));
                resultado.AdicioneResultadoBiometria(validacoes.BiometriaDigital);
                resultado.AdicioneResultadoBiometriaFacial(validacoes.BiometriaFace);
            }

            return resultado;
        }

        private async Task<bool> Autentique()
        {
            var client = new RestClient($"{this._dataValidConfig.UriBase}/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Basic {this._dataValidConfig.ChaveAcesso}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            _token = JsonConvert.DeserializeObject<TokenResponse>(response.Content);
            return true;
        }
    }
}
