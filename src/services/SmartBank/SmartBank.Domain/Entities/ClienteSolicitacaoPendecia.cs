using System;

namespace SmartBank.Domain.Entities
{
    public class ClienteSolicitacaoPendecia : EntityBase
    {
        public DateTime DataPendencia { get; set; }
        public StatusPendenciaSolicitacao Status { get; set; }
        public DateTime DataResolvida { get; set; }
        public TipoPedencia Tipo { get; set; }
        public string Descricao { get; set; }
        public string Resolucao { get; set; }
        public Guid SolicitacaoId { get; set; }
        public ClienteSolicitacao Solicitacao { get; set; }
    }
}
