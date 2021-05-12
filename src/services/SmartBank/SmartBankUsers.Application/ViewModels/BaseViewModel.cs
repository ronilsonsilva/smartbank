using System;

namespace SmartBank.Application.ViewModels
{
    public class BaseViewModel
    {
        public Guid? Id { get; set; }
        public DateTime? Cadastro { get; set; }
        public DateTime? Atualizado { get; set; }
    }
}
