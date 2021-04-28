using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Application.Contracts;
using SmartBank.Application.ViewModels;
using SmartBank.AuthIntegration;
using System.Threading.Tasks;

namespace SmartBank.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : DefaultController<ClienteViewModel>
    {
        protected readonly IAccountService _accountServices;

        public ClienteController(IApplicationServices<ClienteViewModel> applicationServices, IAccountService accountServices) : base(applicationServices)
        {
            _accountServices = accountServices;
        }

        public override async Task<IActionResult> Post([FromBody] ClienteViewModel viewModel)
        {
            //Precisa ser evoluido
            viewModel.Usuario = await this._accountServices.AdicionarUsuario(viewModel.Cpf, viewModel.Contato.Email, viewModel.Contato.TelefoneCelular, viewModel.Password);

            return await base.Post(viewModel);
        }

    }
}
