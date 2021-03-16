using SmartBank.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartBank.Domain.Contracts.Repository
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Adicionar(TEntity entity);
        Task<TEntity> Atualizar(TEntity entity);
        Task<bool> Excluir(Guid id);
        IQueryable<TEntity> Consultar(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Consultar();
        Task<TEntity> Consultar(Guid id);
    }
}
