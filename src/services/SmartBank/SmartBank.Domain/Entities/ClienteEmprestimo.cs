using System;
using System.Collections.Generic;

namespace SmartBank.Domain.Entities
{
    public class ClienteEmprestimo : EntityBase
    {
        public DateTime DataLiberacao { get; set; }
        public decimal ValorEmprestimo { get; set; }
        public int QuantidadeParcela { get; set; }
        public DateTime DataPrimeiraParcela { get; set; }
        public Guid ClienteSolicitacaoId { get; set; }
        public ClienteSolicitacao ClienteSolicitacao { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public IList<ClienteEmprestimoParcela> Parcelas { get; set; }

    }
}
