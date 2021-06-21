using SmartBank.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SmartBank.Domain.Contracts.DomainServices
{
    public interface IClienteSolicitacaoService : IDomainServices<ClienteSolicitacao>
    {
        Task<bool> Aceitar(Guid solicitacaoId);
        Task<bool> Recusar(Guid solicitacaoId);
    }
}
