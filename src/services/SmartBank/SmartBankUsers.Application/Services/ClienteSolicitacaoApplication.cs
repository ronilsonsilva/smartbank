using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartBank.Application.Contracts;
using SmartBank.Application.Verbos;
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
        protected readonly IRepository<ClienteSolicitacaoPendecia> _repositoryPendencia;
        protected readonly IClienteSolicitacaoService _clienteSolicitacaoService;
        public ClienteSolicitacaoApplication(IDomainServices<ClienteSolicitacao> domainServices, IMapper mapper, NotificationContext notificationContext, IRepository<ClienteSolicitacao> repository, IRepository<ClienteSolicitacao> repositoryClienteSolicitacao, IClienteSolicitacaoService clienteSolicitacaoService, IRepository<ClienteSolicitacaoPendecia> repositoryPendencia) : base(domainServices, mapper, notificationContext, repository)
        {
            _repositoryClienteSolicitacao = repositoryClienteSolicitacao;
            _clienteSolicitacaoService = clienteSolicitacaoService;
            _repositoryPendencia = repositoryPendencia;
        }

        public async Task<IList<ClienteSolicitacaoViewModel>> ListarSolicitacoes(Guid clienteId)
        {
            var solicitacoes = await this._repositoryClienteSolicitacao.Consultar(x => x.ClienteId == clienteId).ToListAsync();
            foreach (var solicitacao in solicitacoes)
            {
                solicitacao.Pendencias = await this._repositoryPendencia.Consultar(x => x.SolicitacaoId == solicitacao.Id).ToListAsync();
            }
            return this._mapper.Map<IList<ClienteSolicitacaoViewModel>>(solicitacoes);
        }

        public override async Task<Response<ClienteSolicitacaoViewModel>> Adicionar(ClienteSolicitacaoViewModel entity)
        {
            var entityDomain = this._mapper.Map<ClienteSolicitacao>(entity);
            var retorno = await this._clienteSolicitacaoService.Adicionar(entityDomain);
            return new Response<ClienteSolicitacaoViewModel>(this._mapper.Map<ClienteSolicitacaoViewModel>(retorno));
        }

        public async Task<bool> Aceitar(Guid solicitacaoId)
        {
            return await this._clienteSolicitacaoService.Aceitar(solicitacaoId);
        }

        public async Task<bool> Recusar(Guid solicitacaoId)
        {
            return await this._clienteSolicitacaoService.Recusar(solicitacaoId);
        }
    }
}
