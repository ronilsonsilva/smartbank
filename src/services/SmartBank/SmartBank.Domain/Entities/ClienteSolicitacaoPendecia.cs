using System;

namespace SmartBank.Domain.Entities
{
    public class ClienteSolicitacaoPendecia : EntityBase
    {
        public ClienteSolicitacaoPendecia()
        {

        }

        public ClienteSolicitacaoPendecia(DateTime dataPendencia, StatusPendenciaSolicitacao status, Guid solicitacaoId, TipoPedencia tipo, string descricao)
        {
            DataPendencia = dataPendencia;
            Status = status;
            SolicitacaoId = solicitacaoId;
            Tipo = tipo;
            Descricao = descricao;
        }


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
