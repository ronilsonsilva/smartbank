using System;

namespace SmartBank.Domain.Entities
{
    public class ClienteEmprestimoParcela : EntityBase
    {
        public DateTime DataVencimento { get; set; }
        public DateTime? DataRecebimento { get; set; }
        public decimal Valor { get; set; }
        public decimal Juros { get; set; }
        public decimal Desconto { get; set; }
    }
}
