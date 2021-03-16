using Microsoft.EntityFrameworkCore;
using SmartBank.Domain.Contracts.Repository;
using SmartBank.Domain.Entities;
using SmartBank.Infra.Data.Repository.Context;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartBank.Infra.Data.Repository.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly SmartBankContext _context;

        public RepositoryBase(SmartBankContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Adicionar(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Atualizar(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            this._context.Entry(entity).Property(x => x.Cadastro).IsModified = false;
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual IQueryable<TEntity> Consultar(Expression<Func<TEntity, bool>> expression)
        {
            return this._context.Set<TEntity>().Where(expression).AsQueryable();
        }

        public virtual async Task<TEntity> Consultar(Guid id)
        {
            var entity = await this.Consultar(x => x.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public IQueryable<TEntity> Consultar()
        {
            return this._context.Set<TEntity>().AsQueryable();
        }

        public virtual async Task<bool> Excluir(Guid id)
        {
            var entityRemover = await this.Consultar(id);
            if (entityRemover == null) return false;
            this._context.Set<TEntity>().Remove(entityRemover);
            return (await this._context.SaveChangesAsync()) > 0;
        }
    }
}
