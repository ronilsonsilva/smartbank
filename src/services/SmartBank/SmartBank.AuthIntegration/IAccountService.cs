using RestSharp;
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
    }

    public class AccountServices : IAccountService
    {
        public async Task<string> AdicionarUsuario(string userName, string email, string phoneNumber, string password)
        {
            var usuario = new Models.User(userName: userName, email: email, phoneNumber: phoneNumber);
            Models.User userRetorno = AdicionarUsuario(usuario);

            IRestResponse response = AlterarSenha(password, userRetorno);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return userRetorno.Id;

            return userRetorno.Id;
        }

        private static IRestResponse AlterarSenha(string password, Models.User userRetorno)
        {
            var client = new RestClient("https://apiaccount.ronilson.dev//api/Users/ChangePassword");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(new Models.UserChangePassword(userRetorno.Id, password, password)), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }

        private static Models.User AdicionarUsuario(Models.User usuario)
        {
            var client = new RestClient("https://apiaccount.ronilson.dev//api/Users");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(usuario), ParameterType.RequestBody);
            IRestResponse response = client.Execute<Models.User>(request);
            var userRetorno = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.User>(response.Content);
            return userRetorno;
        }
    }
}
