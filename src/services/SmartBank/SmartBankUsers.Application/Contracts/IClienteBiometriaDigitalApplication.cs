using SmartBank.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBank.Application.Contracts
{
    public interface IClienteBiometriaDigitalApplication : IApplicationServices<ClienteBiometriaDigitalViewModel>
    {
        Task<IList<ClienteBiometriaDigitalViewModel>> ListarBiometrias(Guid clienteId);
    }
}
