using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartBank.Application.Contracts;
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
    public class ClienteBiometriaDigitalApplication : ApplicationServices<ClienteBiometriaDigitalViewModel, ClienteBiometriaDigital>, IClienteBiometriaDigitalApplication
    {
        public ClienteBiometriaDigitalApplication(IDomainServices<ClienteBiometriaDigital> domainServices, IMapper mapper, NotificationContext notificationContext, IRepository<ClienteBiometriaDigital> repository) : base(domainServices, mapper, notificationContext, repository)
        {
            
        }

        public async Task<IList<ClienteBiometriaDigitalViewModel>> ListarBiometrias(Guid clienteId)
        {
            var biometrias = await this._repository.Consultar(x => x.ClienteId == clienteId).ToListAsync();
            return this._mapper.Map<IList<ClienteBiometriaDigitalViewModel>>(biometrias);
        }
    }
}
