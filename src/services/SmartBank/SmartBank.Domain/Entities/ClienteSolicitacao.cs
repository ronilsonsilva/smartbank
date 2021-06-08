using System;
using System.Collections.Generic;

namespace SmartBank.Domain.Entities
{
    public class ClienteSolicitacao : EntityBase
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
        public Cliente Cliente { get; set; }
        public IList<ClienteSolicitacaoPendecia> Pendencias { get; set; }
    }
}
