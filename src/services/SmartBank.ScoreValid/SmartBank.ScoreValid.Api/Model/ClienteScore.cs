using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank.ScoreValid.Api.Model
{
    public class ClienteScore
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public int Score { get; set; }
        public Guid ClienteId { get; set; }
    }
}
