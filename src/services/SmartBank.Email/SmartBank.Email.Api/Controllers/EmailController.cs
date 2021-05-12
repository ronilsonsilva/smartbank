using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Email.Api.Application.Services;
using SmartBank.Email.Api.Models;
using System;
using System.Threading.Tasks;

namespace SmartBank.Email.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        #region [Properties]

        protected readonly IEmailSender _emailSender;

        #endregion

        #region [Constructors]

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        #endregion

        #region [End-Points]

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SenderEmailInputModel model)
        {
            var ok = await this._emailSender.SendEmail(model);

            if (ok)
                return Ok();
            else throw new Exception("Erro ao enviar e-mail");
        }

        #endregion
    }
}
