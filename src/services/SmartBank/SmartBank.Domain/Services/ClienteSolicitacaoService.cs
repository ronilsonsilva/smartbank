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
        protected readonly IRepository<ClienteScore> _repositoryScore;
        protected readonly IRepository<ClienteBiometriaFacial> _repositoryBiometriaFacial;
        protected readonly IRepository<ClienteValidacaoCadastral> _repositoryValidacaoCadastral;
        protected readonly IRepository<ClienteSolicitacaoPendecia> _repositoryPendencias;
        public ClienteSolicitacaoService(IRepository<ClienteSolicitacao> repository, NotificationContext notificationContext, IRepository<Cliente> repositoryCliente, IRepository<ClienteBiometriaFacial> repositoryBiometriaFacial, IRepository<ClienteValidacaoCadastral> repositoryValidacaoCadastral, IRepository<ClienteSolicitacaoPendecia> repositoryPendencias, IRepository<ClienteScore> repositoryScore) : base(repository, notificationContext)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryBiometriaFacial = repositoryBiometriaFacial;
            _repositoryValidacaoCadastral = repositoryValidacaoCadastral;
            _repositoryPendencias = repositoryPendencias;
            _repositoryScore = repositoryScore;
        }

        public async override Task<ClienteSolicitacao> Adicionar(ClienteSolicitacao solicitacao)
        {
            await base.Adicionar(solicitacao);

            var cliente = await this._repositoryCliente.Consultar(solicitacao.ClienteId);
            cliente.BiometriaFacial = await this._repositoryBiometriaFacial.Consultar(x => x.ClienteId == solicitacao.ClienteId).FirstOrDefaultAsync();
            cliente.ValidacaoCadastral = await this._repositoryValidacaoCadastral.Consultar(x => x.ClienteId == solicitacao.ClienteId).FirstOrDefaultAsync();
            cliente.Score = await this._repositoryScore.Consultar(x => x.ClienteId == solicitacao.ClienteId).FirstOrDefaultAsync();

            if (solicitacao.Pendencias == null)
                solicitacao.Pendencias = new List<ClienteSolicitacaoPendecia>();

            if (cliente.RendaMensal == 0)
            {
                var pendencia = await this._repositoryPendencias.Adicionar(new ClienteSolicitacaoPendecia(DateTime.Now, StatusPendenciaSolicitacao.PENDENTE, solicitacao.Id, TipoPedencia.RENDA_MENSAL, "Renda mensal inválida."));
                solicitacao.Pendencias.Add(pendencia);
            }
            else
            {
                //Valor de parcela menor que 30% da renda
                var juros = (solicitacao.ValorSolicitado * (decimal.Parse("0,05"))) * solicitacao.QuantidadeParcela;
                var valorParcela = (solicitacao.ValorSolicitado / solicitacao.QuantidadeParcela) + juros;
                //Parcela compromete Mais que 30% do salário
                if (((valorParcela / cliente.RendaMensal) * 100) > 30)
                {
                    var pendencia = await this._repositoryPendencias.Adicionar(new ClienteSolicitacaoPendecia(DateTime.Now, StatusPendenciaSolicitacao.PENDENTE, solicitacao.Id, TipoPedencia.RENDA_MENSAL, "Parcela compromete mais de 30% da renda mensal."));
                    solicitacao.Pendencias.Add(pendencia);
                }
            }

            if (!cliente.ValidacaoFacial)
            {
                var pendencia = await this._repositoryPendencias.Adicionar(new ClienteSolicitacaoPendecia(DateTime.Now, StatusPendenciaSolicitacao.PENDENTE, solicitacao.Id, TipoPedencia.BIOMETRIA_FACIAL_NAO_RECONHECIDA, $"Validação Facial: {cliente.BiometriaFacial.Probabilidade}."));
                solicitacao.Pendencias.Add(pendencia);
            }

            if (!cliente.CadastroValidado)
            {
                if (cliente.ValidacaoCadastral?.CpfDisponivel != true)
                {
                    var pendencia = await this._repositoryPendencias.Adicionar(new ClienteSolicitacaoPendecia(DateTime.Now, StatusPendenciaSolicitacao.PENDENTE, solicitacao.Id, TipoPedencia.DOCUMENTOS_INVALIDO, $"CPF Indisponível."));
                    solicitacao.Pendencias.Add(pendencia);
                }
                
                if (cliente.ValidacaoCadastral?.SituaçãoCpf != true)
                {
                    var pendencia = await this._repositoryPendencias.Adicionar(new ClienteSolicitacaoPendecia(DateTime.Now, StatusPendenciaSolicitacao.PENDENTE, solicitacao.Id, TipoPedencia.DOCUMENTOS_INVALIDO, $"CPF Indisponível."));
                    solicitacao.Pendencias.Add(pendencia);
                }

                if (cliente.ValidacaoCadastral?.Nome != true)
                {
                    var pendencia = await this._repositoryPendencias.Adicionar(new ClienteSolicitacaoPendecia(DateTime.Now, StatusPendenciaSolicitacao.PENDENTE, solicitacao.Id, TipoPedencia.DOCUMENTOS_INVALIDO, $"Nome inválido."));
                    solicitacao.Pendencias.Add(pendencia);
                }
            }

            if(cliente.Score.Score < 500)
            {
                var pendencia = await this._repositoryPendencias.Adicionar(new ClienteSolicitacaoPendecia(DateTime.Now, StatusPendenciaSolicitacao.PENDENTE, solicitacao.Id, TipoPedencia.DOCUMENTOS_INVALIDO, $"Score muito baixo."));
                solicitacao.Pendencias.Add(pendencia);
            }

            if (solicitacao.Pendencias.Count == 0)
            {
                solicitacao.ValorLiberado = solicitacao.ValorSolicitado;
                solicitacao.Status = StatusSolicitacao.APROVADA;
            }
            else solicitacao.Status = StatusSolicitacao.RECUSADA;
            await this.Atualizar(solicitacao);
            return solicitacao;
        }
    }
}
