using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Application.Contracts;
using SmartBank.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace SmartBank.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        IClienteSolicitacaoApplication _application;

        public SolicitacaoController(IClienteSolicitacaoApplication application)
        {
            _application = application;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClienteSolicitacaoViewModel clienteSolicitacao)
        {
            return Ok(await this._application.Adicionar(clienteSolicitacao));
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

        [HttpGet("Listar/{clienteId}")]
        public virtual async Task<IActionResult> Listar(Guid clienteId)
        {
            return Ok(await this._application.ListarSolicitacoes(clienteId));
        }
    }
}
