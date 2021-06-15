using System;

namespace SmartBank.Domain.Entities
{
    public class ClienteScore : EntityBase
    {
        public int Score { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
