using System;

namespace SmartBank.Application.ViewModels
{
    public class ClienteBiometriaFacialViewModel : BaseViewModel
    {
        public Guid ClienteId { get; set; }
        public string ImageBase64 { get; set; }
        public int Similaridade { get; set; }
        public string Probabilidade { get; set; }
        public bool Valida { get; set; }

    }
}
