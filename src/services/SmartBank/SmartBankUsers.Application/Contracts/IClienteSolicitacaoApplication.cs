using SmartBank.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBank.Application.Contracts
{
    public interface IClienteSolicitacaoApplication : IApplicationServices<ClienteSolicitacaoViewModel>
    {
        Task<IList<ClienteSolicitacaoViewModel>> ListarSolicitacoes(Guid clienteId);
        Task<bool> Aceitar(Guid solicitacaoId);
        Task<bool> Recusar(Guid solicitacaoId);
    }
}
