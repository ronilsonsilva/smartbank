using Microsoft.EntityFrameworkCore;

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
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
