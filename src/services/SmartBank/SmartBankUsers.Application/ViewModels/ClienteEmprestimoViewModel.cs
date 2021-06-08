using System;
using System.Collections.Generic;

namespace SmartBank.Application.ViewModels
{
    public class ClienteEmprestimoViewModel : BaseViewModel
    {
        public DateTime DataLiberacao { get; set; }
        public decimal ValorEmprestimo { get; set; }
        public int QuantidadeParcela { get; set; }
        public DateTime DataPrimeiraParcela { get; set; }
        public Guid ClienteSolicitacaoId { get; set; }
        public ClienteSolicitacaoViewModel ClienteSolicitacao { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public IList<ClienteEmprestimoParcela> Parcelas { get; set; }

    }
}
