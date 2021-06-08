using System;

namespace SmartBank.Application.ViewModels
{
    public class ClienteEmprestimoParcela : BaseViewModel
    {
        public DateTime DataVencimento { get; set; }
        public DateTime? DataRecebimento { get; set; }
        public decimal Valor { get; set; }
        public decimal Juros { get; set; }
        public decimal Desconto { get; set; }
    }
}
