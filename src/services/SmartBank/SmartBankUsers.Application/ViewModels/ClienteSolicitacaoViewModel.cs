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
        public int QuantidadeParcela { get; set; }
        public DateTime VencimentoPrimeiraParcela { get; set; }
        public decimal ValorLiberado { get; set; }
        public DateTime? DataAprovacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public Guid ClienteId { get; set; }
        public IList<ClienteSolicitacaoPendeciaViewModel> Pendencia { get; set; }
    }

    public class NovaSolicitacaoInputModel
    {
        public TipoSolicitacao tipo { get; set; }
        public decimal valorSolicitado { get; set; }
        public int quantidadeParcela { get; set; }
        public DateTime vencimentoPrimeiraParcela { get; set; }
    }
}
