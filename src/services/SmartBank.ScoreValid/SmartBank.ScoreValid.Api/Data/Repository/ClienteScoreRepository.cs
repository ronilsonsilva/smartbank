using Microsoft.EntityFrameworkCore;
using SmartBank.ScoreValid.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank.ScoreValid.Api.Data.Repository
{
    public class ClienteScoreRepository : IClienteScoreRepository
    {
        protected readonly SmartBankScoreContext _context;

        public ClienteScoreRepository(SmartBankScoreContext context)
        {
            _context = context;
        }


        public async Task<ClienteScore> Adicionar(ClienteScore score)
        {
            this._context.Set<ClienteScore>().Add(score);
            await this._context.SaveChangesAsync();
            return score;
        }

        public async Task<ClienteScore> ConsultarDoCliente(Guid clienteId)
        {
            return await this._context.Set<ClienteScore>().Where(x => x.ClienteId == clienteId).FirstOrDefaultAsync();
        }
    }

    public interface IClienteScoreRepository
    {
        Task<ClienteScore> Adicionar(ClienteScore score);
        Task<ClienteScore> ConsultarDoCliente(Guid clienteId);
    }
}
