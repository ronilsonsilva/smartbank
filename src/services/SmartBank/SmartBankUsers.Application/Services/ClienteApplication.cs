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
using System.Threading.Tasks;

namespace SmartBank.Application.Services
{
    public class ClienteApplication : ApplicationServices<ClienteViewModel, Cliente>, IClienteApplication
    {
        protected readonly IRepository<ClienteBiometriaFacial> _repositoryBiometriaFacial;
        protected readonly IDomainServices<ClienteBiometriaFacial> _serviceBiometriaFacial;

        public ClienteApplication(IDomainServices<Cliente> domainServices, IMapper mapper, NotificationContext notificationContext, IRepository<Cliente> repository, IRepository<ClienteBiometriaFacial> repositoryBiometriaFacial, IDomainServices<ClienteBiometriaFacial> serviceBiometriaFacial) : base(domainServices, mapper, notificationContext, repository)
        {
            _repositoryBiometriaFacial = repositoryBiometriaFacial;
            _serviceBiometriaFacial = serviceBiometriaFacial;
        }

        public async Task<Guid> ObterIdAtualCliente(string email)
        {
            var cliente = await this._repository.Consultar(x => x.Contato.Email.Equals(email)).FirstOrDefaultAsync();
            return cliente.Id;
        }

        public async Task<Response<bool>> SalvarSelfie(ClienteSefieInputModel model)
        {
            var biometriaExistente = await this._repositoryBiometriaFacial.Consultar(x => x.ClienteId == model.ClienteId).FirstOrDefaultAsync();
            if (biometriaExistente != null)
            {
                biometriaExistente.ImageBase64 = model.ImageBase64;
                var response = await this._serviceBiometriaFacial.Atualizar(biometriaExistente);
                return new Response<bool>();
            }
            else
            {
                var biometria = new ClienteBiometriaFacial()
                {
                    ClienteId = model.ClienteId,
                    ImageBase64 = model.ImageBase64
                };
                var response = await this._serviceBiometriaFacial.Adicionar(biometria);
                return new Response<bool>();
            }
        }
    }
}
