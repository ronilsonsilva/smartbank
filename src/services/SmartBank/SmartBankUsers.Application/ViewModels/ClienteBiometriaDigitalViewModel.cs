using System;

namespace SmartBank.Application.ViewModels
{
    public class ClienteBiometriaDigitalViewModel : BaseViewModel
    {
        public Guid ClienteId { get; set; }
        public string BiometriaBase64 { get; set; }
        public int Posicao { get; set; }
        public int Similaridade { get; set; }
        public string Probalidade { get; set; }
        public bool Valida { get; set; }
    }
}
