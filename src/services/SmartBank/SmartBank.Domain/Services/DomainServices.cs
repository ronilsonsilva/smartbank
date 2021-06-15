using SmartBank.Domain.Contracts.DomainServices;
using SmartBank.Domain.Contracts.Repository;
using SmartBank.Domain.Entities;
using SmartBank.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace SmartBank.Domain.Services
{
    public class DomainServices<TEntity> : IDomainServices<TEntity> where TEntity : EntityBase
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly NotificationContext _notificationContext;

        public DomainServices(IRepository<TEntity> repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public virtual async Task<TEntity> Adicionar(TEntity entity)
        {
            //validações
            if (entity.Invalid)
            {
                this._notificationContext.AddNotifications(entity.ValidationResult);
                return entity;
            }

            return await this._repository.Adicionar(entity);
        }

        public virtual async Task<TEntity> Atualizar(TEntity entity)
        {
            //Validações do dominio

            return await this._repository.Atualizar(entity);
        }

        public virtual async Task<bool> Excluir(Guid id)
        {
            //validações 

            return await this._repository.Excluir(id);
        }
    }
}
