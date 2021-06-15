using System;

namespace SmartBank.Application.ViewModels
{
    public class ClienteValidacaoCadastralViewModel : BaseViewModel
    {
        public Guid ClienteId { get; set; }
        public bool Nome { get; set; }
        public bool CpfDisponivel { get; set; }
        public bool NomeSimilaridade { get; set; }
        public bool DataNascimento { get; set; }
        public bool SituaçãoCpf { get; set; }
    }
}
