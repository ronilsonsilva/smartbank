using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Application.Contracts;
using SmartBank.Application.ViewModels;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartBank.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        protected readonly IClienteSolicitacaoApplication _application;
        protected readonly IClienteApplication _clienteApplication;

        public SolicitacaoController(IClienteSolicitacaoApplication application, IClienteApplication clienteApplication)
        {
            _application = application;
            _clienteApplication = clienteApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteSolicitacaoViewModel model)
        {
            model.ClienteId = await this._clienteApplication.ObterIdAtualCliente(this.User.FindFirstValue(ClaimTypes.Email));
            return Ok(await this._application.Adicionar(model));
        }
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ClienteSolicitacaoViewModel clienteSolicitacao)
        {
            return Ok(await this._application.Atualizar(clienteSolicitacao));
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            return Ok(await this._application.Consultar(id));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Listar()
        {
            var clienteId = await this._clienteApplication.ObterIdAtualCliente(this.User.FindFirstValue(ClaimTypes.Email));
            return Ok(await this._application.ListarSolicitacoes(clienteId));
        }
    }
}
