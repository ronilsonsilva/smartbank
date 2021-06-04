using SmartBank.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartBank.Application.ViewModels
{
    public class ClienteSolicitacaoViewModel : BaseViewModel
    {
        public DateTime Data { get; set; }
        public TipoSolicitacao Tipo { get; set; }
        public StatusSolicitacao Status { get; set; }
        public decimal ValorSolicitado { get; set; }
        public decimal ValorLiberado { get; set; }
        public DateTime? DataAprovacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public Guid ClienteId { get; set; }
        public IList<ClienteSolicitacaoPendeciaViewModel> Pendencia { get; set; }
    }
}
