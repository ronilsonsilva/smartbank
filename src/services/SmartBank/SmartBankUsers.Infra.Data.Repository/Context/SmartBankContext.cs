using Microsoft.EntityFrameworkCore;
using SmartBank.Infra.Data.Repository.Context.Map;

namespace SmartBank.Infra.Data.Repository.Context
{
    public class SmartBankContext : DbContext
    {
        public SmartBankContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
