using EasyNetQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SmartBank.Application.Contracts;
using SmartBank.Application.ViewModels;
using SmartBank.AuthIntegration;
using SmartBank.MessageBus;
using SmartBank.Shared.Messages.Integration;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : DefaultController<ClienteViewModel>
    {
        protected readonly IAccountService _accountServices;
        protected readonly IMessageBus _bus;
        protected readonly IClienteApplication _application;

        public ClienteController(IClienteApplication applicationServices, IAccountService accountServices, IMessageBus bus) : base(applicationServices)
        {
            _accountServices = accountServices;
            _bus = bus;
            _application = applicationServices;
        }

        [AllowAnonymous]
        public override async Task<IActionResult> Post([FromBody] ClienteViewModel viewModel)
        {
            //Precisa ser evoluido
            viewModel.Usuario = await this._accountServices.AdicionarUsuario(viewModel.Cpf, viewModel.Contato.Email, viewModel.Contato.TelefoneCelular, viewModel.Password);

            var retorno = await base.Post(viewModel);

            var usuarioRegistradoEvent = new ClienteRegistradoIntegrationEvent(nome: viewModel.Nome, email: viewModel.Contato.Email, usuario: viewModel.Cpf);

            try
            {
                //var _bus = RabbitHutch.CreateBus("host=209.126.1.140;username=admin;password=Sig@2021");

                //await _bus.PublishAsync<ClienteRegistradoIntegrationEvent>(usuarioRegistradoEvent);

                await this._bus.PublishAsync<ClienteRegistradoIntegrationEvent>(usuarioRegistradoEvent);
            }
            catch (Exception ex)
            {

            }

            return Ok(viewModel);
        }


        [HttpPost("salvar-selfie")]
        public async Task<IActionResult> SalvarSefie([FromBody] ClienteSefieInputModel model)
        {
            model.ClienteId = await this._application.ObterIdAtualCliente(this.User.FindFirstValue(ClaimTypes.Email));
            var response = await this._application.SalvarSelfie(model);
            if (response.Ok)
            {
                try
                {
                    await this._bus.PublishAsync<BiometriaFacialAdicionadoIntegrationEvent>(new BiometriaFacialAdicionadoIntegrationEvent(clienteId: model.ClienteId, imageBase64: model.ImageBase64));
                }
                catch (Exception ex)
                {
                }
            }

            return Ok(response);
        }

        [HttpGet("info")]
        public async Task<IActionResult> Info()
        {
            var clienteId = await this._application.ObterIdAtualCliente(this.User.FindFirstValue(ClaimTypes.Email));
            return Ok(await this._application.Consultar(clienteId));
        }

        [HttpPut]
        public async override Task<IActionResult> Put([FromBody] ClienteViewModel viewModel)
        {
            return Ok(await this._application.Atualizar(viewModel));
        }

        [AllowAnonymous]
        [HttpGet("codigo-redefinir-senha/{cpf}")]
        public async Task<IActionResult> CodigoRedefinir(string cpf)
        {
            var cliente = await this._application.ConsultarPorCpf(cpf);
            if (cliente == null) return NotFound();
            
            var codigo = new Random().Next(minValue: 100000, maxValue: 999999);
            cliente.ValidadeCodigoRedefinicaoSenha = DateTime.Now.AddMinutes(15);
            cliente.CodigoRedefinicaoSenha = this.MD5Hash(codigo.ToString());
            var emailEnviado = await this.EnviarCodigo(codigo.ToString(), cliente.Contato.Email, cliente.Nome);
            if (emailEnviado)
            {
                await this._application.AtualizarCodigo(cliente);
                return Ok();
            }
            return UnprocessableEntity();
        }

        [AllowAnonymous]
        [HttpPost("redefinir-senha")]
        public async Task<IActionResult> RedefinirSenha([FromBody] RedefinirSenhaViewModel model)
        {
            var hashCodigo = this.MD5Hash(model.Codigo);
            var cliente = await this._application.ConsultarPorCodigoDefinicaoSenha(hashCodigo);
            if (cliente == null) return NotFound();

            if(cliente.CodigoRedefinicaoSenha == hashCodigo && DateTime.Now <= cliente.ValidadeCodigoRedefinicaoSenha)
            {
                var senhaRedefinida = await this._accountServices.RedefinirSenha(new AuthIntegration.Models.AlterarSenhaModel(confirmPassword: model.ConfirmacaoSenha, password: model.Senha, userId: cliente.Usuario));
                if (senhaRedefinida) return Ok();
            }
            return UnprocessableEntity();
        }

        #region [Auxiliares]

        private string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private async Task<bool> EnviarCodigo(string codigo, string emailCliente, string nomeCliente)
        {
            var client = new RestClient("https://sbemail.ronilson.dev/api/Email");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {this._accountServices.GetToken()}");
            var conteudo = new EnviarEmailViewModel(
                nomeDestinatario: nomeCliente, 
                emailRemetente: "nao-responda@smartbank.app", 
                mensagem: $"Olá {nomeCliente}, segue seu código de redefinição de senha do Smart Bank: {codigo}. Caso não tenha solicitado, por favor, desconsidere.", 
                emailDestinatario: emailCliente, 
                nomeRemetente: "Gestão de Contas Smart Bank");
            var body = JsonConvert.SerializeObject(conteudo);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            return (response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        #endregion

    }
}
