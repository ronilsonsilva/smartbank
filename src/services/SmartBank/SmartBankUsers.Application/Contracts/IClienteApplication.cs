using SmartBank.Application.Verbos;
using SmartBank.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace SmartBank.Application.Contracts
{
    public interface IClienteApplication : IApplicationServices<ClienteViewModel>
    {
        Task<Guid> ObterIdAtualCliente(string email);
        Task<Response<bool>> SalvarSelfie(ClienteSefieInputModel model);
    }
}
