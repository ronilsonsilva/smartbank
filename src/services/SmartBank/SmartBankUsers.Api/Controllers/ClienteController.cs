using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Application.Contracts;
using SmartBank.Application.ViewModels;

namespace SmartBank.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : DefaultController<ClienteViewModel>
    {
        public ClienteController(IApplicationServices<ClienteViewModel> applicationServices) : base(applicationServices)
        {
        }
    }
}
