using System;

namespace SmartBank.Domain.Entities
{
    public class ClienteBiometriaFacial : EntityBase
    {
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string ImageBase64 { get; set; }
        public int Similaridade { get; set; }
        public string Probabilidade { get; set; }
        public bool Valida 
        {
            get 
            {
                if (this.Probabilidade == null || this.Similaridade == null)
                    return false;

                return (this.Probabilidade.Equals("Altíssima probabilidade") || this.Probabilidade.Equals("Alta probabilidade")) && (this.Similaridade == 1 || this.Similaridade == 2);
            }
        }

    }
}
