using Microsoft.AspNetCore.Mvc;
using SmartBank.Application.Contracts;
using SmartBank.Application.Verbos;
using SmartBank.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank.Api.Controllers
{
    [ApiController]
    public class DefaultController<TEntityViewModel> : ControllerBase where TEntityViewModel : BaseViewModel
    {
        #region [Fields/Properties]

        protected readonly IApplicationServices<TEntityViewModel> _applicationServices;

        #endregion

        #region [Constructors]

        public DefaultController(IApplicationServices<TEntityViewModel> applicationServices)
        {
            _applicationServices = applicationServices;
        }

        #endregion

        #region [Endpoints]

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TEntityViewModel viewModel)
        {
            var result = await this._applicationServices.Adicionar(viewModel);
            return Ok(result);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TEntityViewModel viewModel)
        {
            var result = await this._applicationServices.Atualizar(viewModel);
            return this.DefaultResponse(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            return this.DefaultResponse(await this._applicationServices.Consultar(id));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return this.DefaultResponse(await this._applicationServices.Consultar());
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            return this.DefaultResponse(await this._applicationServices.Excluir(id));
        }

        protected IActionResult DefaultResponse(Response<object> response)
        {
            return Ok(response);
        }

        #endregion

        #region [Default Response]

        protected IActionResult DefaultResponse(Response<TEntityViewModel> response)
        {
            return Ok(response);
        }

        protected IActionResult DefaultResponse(Response<bool> response)
        {
            return Ok(response);
        }

        protected IActionResult DefaultResponse(TEntityViewModel entity = null)
        {
            if (entity == null) return NoContent();
            return Ok(entity);
        }

        protected IActionResult DefaultResponse(ICollection<TEntityViewModel> entities = null)
        {
            if (entities?.Count() == 0) return NoContent();
            return Ok(entities);
        }

        #endregion
    }
}
