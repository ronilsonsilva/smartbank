using System;

namespace SmartBank.Application.ViewModels
{
    public class ClienteScoreViewModel : BaseViewModel
    {
        public int Score { get; set; }
        public Guid ClienteId { get; set; }
    }
}
