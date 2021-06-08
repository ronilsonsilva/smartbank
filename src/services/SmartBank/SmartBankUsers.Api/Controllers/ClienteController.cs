using EasyNetQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Application.Contracts;
using SmartBank.Application.ViewModels;
using SmartBank.AuthIntegration;
using SmartBank.MessageBus;
using SmartBank.Shared.Messages.Integration;
using System;
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

        public ClienteController(IApplicationServices<ClienteViewModel> applicationServices, IAccountService accountServices, IMessageBus bus) : base(applicationServices)
        {
            _accountServices = accountServices;
            _bus = bus;
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

    }
}
