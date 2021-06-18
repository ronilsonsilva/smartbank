using Newtonsoft.Json;
using RestSharp;
using SmartBank.AuthIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.AuthIntegration
{
    public interface IAccountService
    {
        Task<string> AdicionarUsuario(string userName, string email, string phoneNumber, string password);
        string GetToken();
        Task<bool> RedefinirSenha(AlterarSenhaModel model);
    }

    public class AccountService : IAccountService
    {
        private ResponseToken _token;
        public AccountService()
        {
            this.GetToken();
        }

        public async Task<string> AdicionarUsuario(string userName, string email, string phoneNumber, string password)
        {
            var usuario = new User(userName: userName, email: email, phoneNumber: phoneNumber);
            User userRetorno = AdicionarUsuario(usuario);

            IRestResponse response = AlterarSenha(password, userRetorno);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return userRetorno.Id;

            return userRetorno.Id;
        }

        public async Task<bool> RedefinirSenha(AlterarSenhaModel model)
        {
            var client = new RestClient("https://apiaccount.ronilson.dev/api/Users/ChangePassword");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {this._token.AccessToken}");
            var body = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK; ;
        }


        private IRestResponse AlterarSenha(string password, Models.User userRetorno)
        {
            var client = new RestClient("https://apiaccount.ronilson.dev/api/Users/ChangePassword");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {this._token.AccessToken}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new Models.UserChangePassword(userRetorno.Id, password, password)), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }

        private Models.User AdicionarUsuario(Models.User usuario)
        {
            var client = new RestClient("https://apiaccount.ronilson.dev/api/Users");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {this._token.AccessToken}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(usuario), ParameterType.RequestBody);
            IRestResponse response = client.Execute<Models.User>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.Created)
                return null;

            var userRetorno = JsonConvert.DeserializeObject<Models.User>(response.Content);
            return userRetorno;
        }


        public string  GetToken()
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
            return this._token.AccessToken;
        }
    }
}
