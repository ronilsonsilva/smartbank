using Newtonsoft.Json;
using RestSharp;
using SmartBank.Application.Contracts;
using SmartBank.Application.ViewModels.DataValid;
using System;
using System.Threading.Tasks;

namespace SmartBank.Application.Services
{
    public class DatavalidIntegrationServices : IDatavalidIntegrationServices
    {
        protected ResponseToken _token;
        public DatavalidIntegrationServices()
        {
            this.GetToken();
        }

        public async Task<ResultadoValidacoes> BasicaPessoaFisica(ValidarPessoaFisica dados)
        {
            var validacao = new ResultadoValidacoes();

            var client = new RestClient("https://sbdatavalid.ronilson.dev/api/Validacoes/BasicoPessoaFisica");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {this._token.AccessToken}");
            var body = JsonConvert.SerializeObject(dados);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                validacao = JsonConvert.DeserializeObject<ResultadoValidacoes>(response.Content);
            

            return validacao;
        }

        public async Task<ResultadoValidacoes> BiometriaFacial(ValidarPessoaFisica dados)
        {
            var validacao = new ResultadoValidacoes();

            var client = new RestClient("https://sbdatavalid.ronilson.dev/api/Validacoes/BiometriaFacialPF");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {this._token.AccessToken}");
            var body = JsonConvert.SerializeObject(dados);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                validacao = JsonConvert.DeserializeObject<ResultadoValidacoes>(response.Content);


            return validacao;
        }

        public Task<ResultadoValidacoes> DigitalPessoaFisica(ValidarPessoaFisica dados)
        {
            throw new NotImplementedException();
        }

        public Task<ResultadoValidacoes> ValidacaoImagem(ValidarPessoaFisica dados)
        {
            throw new NotImplementedException();
        }

        #region [Auxiliares]

        private void GetToken()
        {
            var client = new RestClient("https://sso.ronilson.dev/connect/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("client_id", "client_smart_bank");
            request.AddParameter("client_secret", "j1VawF2gqa0qTH616C+0/EsKYh7odDpLE5MRhXZyqNM=");
            request.AddParameter("scope", "clientAdmin_api");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", "admin");
            request.AddParameter("password", "$ig@Me$7re");
            IRestResponse response = client.Execute(request);

            this._token = JsonConvert.DeserializeObject<ResponseToken>(response.Content);
        }

        #endregion
    }
}
