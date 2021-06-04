using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBank.Application.Contracts;
using SmartBank.Application.Services;
using SmartBank.Application.ViewModels;
using SmartBank.AuthIntegration;
using SmartBank.Domain.Contracts.DomainServices;
using SmartBank.Domain.Contracts.Repository;
using SmartBank.Domain.Entities;
using SmartBank.Domain.Notifications;
using SmartBank.Domain.Services;
using SmartBank.Infra.Data.Repository.Context;
using SmartBank.Infra.Data.Repository.Repositories;

namespace SmartBank.Infra.CrossCutting.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region [Configurações]

            var connection = configuration["CONNECTION_STRING:SmartBankContext"];
            services.AddDbContext<SmartBankContext>
                (options =>
                    options.UseNpgsql(connection)
                );
            services.AddScoped<SmartBankContext, SmartBankContext>();
            services.AddScoped<NotificationContext>();

            #endregion

            #region [Email]

            //Configuração do E-mail


            #endregion

            #region [Application Services]

            services.AddScoped<IApplicationServices<ClienteViewModel>, ApplicationServices<ClienteViewModel, Cliente>>();
            services.AddScoped<IApplicationServices<ClienteSolicitacaoViewModel>, ApplicationServices<ClienteSolicitacaoViewModel, ClienteSolicitacao>>();
            services.AddScoped<IApplicationServices<ClienteSolicitacaoPendeciaViewModel>, ApplicationServices<ClienteSolicitacaoPendeciaViewModel, ClienteSolicitacaoPendecia>>();
            services.AddScoped<IApplicationServices<ClienteBiometriaDigitalViewModel>, ApplicationServices<ClienteBiometriaDigitalViewModel, ClienteBiometriaDigital>>();
            services.AddScoped<IClienteBiometriaDigitalApplication, ClienteBiometriaDigitalApplication>();

            #endregion

            #region [Domain Services]

            services.AddScoped<IDomainServices<Cliente>, DomainServices<Cliente>>();
            services.AddScoped<IDomainServices<ClienteBiometriaDigital>, DomainServices<ClienteBiometriaDigital>>();
            services.AddScoped<IDomainServices<ClienteSolicitacao>, DomainServices<ClienteSolicitacao>>();
            services.AddScoped<IDomainServices<ClienteSolicitacaoPendecia>, DomainServices<ClienteSolicitacaoPendecia>>();

            #endregion

            #region [Services Repositories]

            services.AddScoped<IRepository<Cliente>, RepositoryBase<Cliente>>();
            services.AddScoped<IRepository<ClienteBiometriaDigital>, RepositoryBase<ClienteBiometriaDigital>>();
            services.AddScoped<IRepository<ClienteSolicitacao>, RepositoryBase<ClienteSolicitacao>>();
            services.AddScoped<IRepository<ClienteSolicitacaoPendecia>, RepositoryBase<ClienteSolicitacaoPendecia>>();

            #endregion

            #region [Integrações]

            services.AddScoped<IAccountService, AccountService>();

            #endregion
        }
    }
}
