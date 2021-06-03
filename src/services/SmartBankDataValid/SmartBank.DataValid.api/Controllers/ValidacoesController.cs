using Microsoft.AspNetCore.Mvc;
using SmartBank.DataValid.Api.Integrations;
using SmartBank.DataValid.Api.Integrations.Models;
using SmartBank.DataValid.Api.Integrations.Models.BasicoValidarPF;
using System.Net;
using System.Threading.Tasks;

namespace SmartBank.DataValid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidacoesController : ControllerBase
    {
        protected readonly IDataValidIntegrationServices _dataValidServices;

        public ValidacoesController(IDataValidIntegrationServices dataValidServices)
        {
            _dataValidServices = dataValidServices;
        }

        [HttpPost("BasicoPessoaFisica")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(ResultadoValidacoes))]
        public async Task<IActionResult> BasicoPessoaFisica([FromBody]ValidarPessoaFisica validarPessoaFisica)
        {
            return Ok(await this._dataValidServices.BasicaPessoaFisica(dados: validarPessoaFisica));
        }

        [HttpPost("BiometriaDigitalPF")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(ResultadoValidacoes))]
        public async Task<IActionResult> BiometriaDigitalPF([FromBody]ValidarPessoaFisica validarPessoaFisica)
        {
            return Ok(await this._dataValidServices.DigitalPessoaFisica(dados: validarPessoaFisica));
        }

        [HttpPost("BiometriaFacialPF")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(ResultadoValidacoes))]
        public async Task<IActionResult> BiometriaFacialPF([FromBody]ValidarPessoaFisica validarPessoaFisica)
        {
            return Ok(await this._dataValidServices.BiometriaFacial(dados: validarPessoaFisica));
        }

        [HttpPost("ImagemPF")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(ResultadoValidacoes))]
        public async Task<IActionResult> ImagemPF([FromBody]ValidarPessoaFisica validarPessoaFisica)
        {
            return Ok(await this._dataValidServices.ValidacaoImagem(dados: validarPessoaFisica));
        }
    }
}
