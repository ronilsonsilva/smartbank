using SmartBank.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SmartBank.Domain.Contracts.DomainServices
{
    public interface IDomainServices<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Adicionar(TEntity entity);
        Task<TEntity> Atualizar(TEntity entity);
        Task<bool> Excluir(Guid id);
    }
}
