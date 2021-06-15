using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBank.ScoreValid.Api.Data.Repository;
using SmartBank.ScoreValid.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank.ScoreValid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteScoreController : ControllerBase
    {
        protected readonly IClienteScoreRepository _repository;

        public ClienteScoreController(IClienteScoreRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClienteScore score)
        {
            return Ok(await this._repository.Adicionar(score));
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid clienteId)
        {
            return Ok(await this._repository.ConsultarDoCliente(clienteId));
        }
    }
}
