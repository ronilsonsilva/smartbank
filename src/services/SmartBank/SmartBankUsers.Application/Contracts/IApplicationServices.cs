using SmartBank.Application.Verbos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBank.Application.Contracts
{
    public interface IApplicationServices<TEntityViewModel>
    {
        Task<Response<TEntityViewModel>> Adicionar(TEntityViewModel entity);
        Task<Response<TEntityViewModel>> Atualizar(TEntityViewModel entity);
        Task<Response<bool>> Excluir(Guid id);
        Task<IList<TEntityViewModel>> Consultar();
        Task<TEntityViewModel> Consultar(Guid id);
    }
}
