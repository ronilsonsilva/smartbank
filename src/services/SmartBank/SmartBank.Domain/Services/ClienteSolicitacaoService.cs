using Microsoft.EntityFrameworkCore;
using SmartBank.Domain.Contracts.DomainServices;
using SmartBank.Domain.Contracts.Repository;
using SmartBank.Domain.Entities;
using SmartBank.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank.Domain.Services
{
    public class ClienteSolicitacaoService : DomainServices<ClienteSolicitacao>, IClienteSolicitacaoService
    {
        protected readonly IRepository<Cliente> _repositoryCliente;
        protected readonly IRepository<ClienteBiometriaFacial> _repositoryBiometriaFacial;
        protected readonly IRepository<ClienteValidacaoCadastral> _repositoryValidacaoCadastral;
        protected readonly IRepository<ClienteSolicitacaoPendecia> _repositoryPendencias;
        public ClienteSolicitacaoService(IRepository<ClienteSolicitacao> repository, NotificationContext notificationContext, IRepository<Cliente> repositoryCliente, IRepository<ClienteBiometriaFacial> repositoryBiometriaFacial, IRepository<ClienteValidacaoCadastral> repositoryValidacaoCadastral, IRepository<ClienteSolicitacaoPendecia> repositoryPendencias) : base(repository, notificationContext)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryBiometriaFacial = repositoryBiometriaFacial;
            _repositoryValidacaoCadastral = repositoryValidacaoCadastral;
            _repositoryPendencias = repositoryPendencias;
        }

        public async override Task<ClienteSolicitacao> Adicionar(ClienteSolicitacao solicitacao)
        {
            await base.Adicionar(solicitacao);

            var cliente = await this._repositoryCliente.Consultar(solicitacao.ClienteId);
            cliente.BiometriaFacial = await this._repositoryBiometriaFacial.Consultar(x => x.ClienteId == solicitacao.ClienteId).FirstOrDefaultAsync();
            cliente.ValidacaoCadastral = await this._repositoryValidacaoCadastral.Consultar(x => x.ClienteId == solicitacao.ClienteId).FirstOrDefaultAsync();
            bool aprovado = false;
            if (solicitacao.Pendencias == null)
                solicitacao.Pendencias = new List<ClienteSolicitacaoPendecia>();

            if (cliente.RendaMensal == 0)
            {
                var pendencia = await this._repositoryPendencias.Adicionar(new ClienteSolicitacaoPendecia(DateTime.Now, StatusPendenciaSolicitacao.PENDENTE, solicitacao.Id, TipoPedencia.RENDA_MENSAL, "Renda mensal inválida"));
                solicitacao.Pendencias.Add(pendencia);
            }

            //Valor de parcela menor que 30% da renda
            var valorParcela = solicitacao.ValorSolicitado / solicitacao.QuantidadeParcela;
            var restante = solicitacao.ValorSolicitado;
            for (int i = 1; i <= solicitacao.QuantidadeParcela; i++)
            {

            }

            if(solicitacao.q)
            
        }
    }
}
