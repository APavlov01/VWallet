using Microsoft.EntityFrameworkCore;
using VWallet.Data.Models;
using VWallet.Models;

namespace VWallet.Data
{
    public class VWalletContext : DbContext
    {
        public VWalletContext()
        {

        }

        public VWalletContext(DbContextOptions dbContextOption)
            : base(dbContextOption) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Income>();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Expense>();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Type>();
        }

        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Models.Type> Types { get; set; }
    }
}
