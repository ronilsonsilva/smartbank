using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartBank.Application.Contracts;
using SmartBank.Application.ViewModels;
using SmartBank.Domain.Contracts.DomainServices;
using SmartBank.Domain.Contracts.Repository;
using SmartBank.Domain.Entities;
using SmartBank.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBank.Application.Services
{
    public class ClienteSolicitacaoApplication : ApplicationServices<ClienteSolicitacaoViewModel, ClienteSolicitacao>, IClienteSolicitacaoApplication
    {
        protected readonly IRepository<ClienteSolicitacao> _repositoryClienteSolicitacao;
        public ClienteSolicitacaoApplication(IDomainServices<ClienteSolicitacao> domainServices, IMapper mapper, NotificationContext notificationContext, IRepository<ClienteSolicitacao> repository, IRepository<ClienteSolicitacao> repositoryClienteSolicitacao) : base(domainServices, mapper, notificationContext, repository)
        {
            _repositoryClienteSolicitacao = repositoryClienteSolicitacao;
        }

        public async Task<IList<ClienteSolicitacaoViewModel>> ListarSolicitacoes(Guid clienteId)
        {
            var solicitacoes = await this._repositoryClienteSolicitacao.Consultar(x => x.ClienteId == clienteId).ToListAsync();
            return this._mapper.Map<IList<ClienteSolicitacaoViewModel>>(solicitacoes);
        }
    }
}
