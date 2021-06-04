using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Application.Contracts;
using SmartBank.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiometriaDigitalController : ControllerBase
    {
        protected readonly IClienteBiometriaDigitalApplication _applicationServices;

        public BiometriaDigitalController(IClienteBiometriaDigitalApplication applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteBiometriaDigitalViewModel clienteBiometria)
        {
            return Ok(await this._applicationServices.Adicionar(clienteBiometria));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteBiometriaDigitalViewModel clienteBiometria)
        {
            return Ok(await this._applicationServices.Atualizar(clienteBiometria));
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            return Ok(await this._applicationServices.Consultar(id));
        }

        [HttpGet("Listar/{clienteId}")]
        public virtual async Task<IActionResult> Listar(Guid clienteId)
        {
            return Ok(await this._applicationServices.ListarBiometrias(clienteId));
        }
    }
}
