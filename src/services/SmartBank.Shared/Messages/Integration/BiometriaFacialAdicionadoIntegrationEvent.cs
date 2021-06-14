using System;

namespace SmartBank.Shared.Messages.Integration
{
    public class BiometriaFacialAdicionadoIntegrationEvent : IntegrationEvent
    {
        public BiometriaFacialAdicionadoIntegrationEvent(Guid clienteId, string imageBase64)
        {
            ClienteId = clienteId;
            ImageBase64 = imageBase64;
        }

        public Guid ClienteId { get; set; }
        public string ImageBase64 { get; set; }
    }
    
}
