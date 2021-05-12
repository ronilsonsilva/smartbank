using FluentValidation.Results;
using Microsoft.Extensions.Hosting;
using SmartBank.Email.Api.Models;
using SmartBank.MessageBus;
using SmartBank.Shared.Messages.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBank.Email.Api.Application.Services
{
    public class ClienteRegistradoIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;
        private readonly IEmailSender _emailSender;


        public ClienteRegistradoIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider, IEmailSender emailSender)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
            _emailSender = emailSender;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<ClienteRegistradoIntegrationEvent, ResponseMessage>(async request =>
                await EnviarEmailBoasVindasCliente(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        private void OnConnect(object s, EventArgs e)
        {
            SetResponder();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }


        private async Task<ResponseMessage> EnviarEmailBoasVindasCliente(ClienteRegistradoIntegrationEvent clienteRegistrado)
        {
            var emailEnviado = await this._emailSender.SendEmail(new SenderEmailInputModel(nomeDestinatario: clienteRegistrado.Nome, emailRemetente: "contato@smartbank.com", mensagem: "Seja bem vindo ao SmartBank!!!", emailDestinatario: clienteRegistrado.Email, nomeRemetente: "Smart Bank"));
            ValidationResult result = new ValidationResult();
            if (!emailEnviado)
                result.Errors.Add(new ValidationFailure(clienteRegistrado.Usuario, "Não foi possível enviar email de boas vindas."));

            return new ResponseMessage(result);
        }

    }
}
