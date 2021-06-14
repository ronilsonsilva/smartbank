using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartBank.Application.Contracts;
using SmartBank.Application.Verbos;
using SmartBank.Application.ViewModels;
using SmartBank.Domain.Contracts.DomainServices;
using SmartBank.Domain.Contracts.Repository;
using SmartBank.Domain.Entities;
using SmartBank.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBank.Application.Services
{
    public class ApplicationServices<TEntityViewModel, TEntity> : IApplicationServices<TEntityViewModel> where TEntityViewModel : BaseViewModel where TEntity : EntityBase
    {
        protected readonly IMapper _mapper;
        protected readonly IDomainServices<TEntity> _domainServices;
        protected readonly IRepository<TEntity> _repository;
        protected readonly NotificationContext _notificationContext;

        public ApplicationServices(IDomainServices<TEntity> domainServices, IMapper mapper, NotificationContext notificationContext, IRepository<TEntity> repository)
        {
            _domainServices = domainServices;
            _mapper = mapper;
            _notificationContext = notificationContext;
            _repository = repository;
        }

        public async Task<Response<TEntityViewModel>> Adicionar(TEntityViewModel entity)
        {
            var entityDomain = this._mapper.Map<TEntity>(entity);
            var retorno = await this._domainServices.Adicionar(entityDomain);
            return new Response<TEntityViewModel>(this._mapper.Map<TEntityViewModel>(retorno));
        }

        public async Task<Response<TEntityViewModel>> Atualizar(TEntityViewModel entity)
        {
            var entityDomain = this._mapper.Map<TEntity>(entity);
            var retorno = await this._domainServices.Atualizar(entityDomain);
            return new Response<TEntityViewModel>(this._mapper.Map<TEntityViewModel>(retorno));
        }

        public async Task<IList<TEntityViewModel>> Consultar()
        {
            var dados = await this._repository.Consultar().ToListAsync();
            return this._mapper.Map<IList<TEntityViewModel>>(dados);
        }

        public async Task<TEntityViewModel> Consultar(Guid id)
        {
            var entity = await this._repository.Consultar(id);
            return this._mapper.Map<TEntityViewModel>(entity);
        }

        public async Task<Response<bool>> Excluir(Guid id)
        {
            return new Response<bool>(await this._domainServices.Excluir(id));
        }

    }
}
