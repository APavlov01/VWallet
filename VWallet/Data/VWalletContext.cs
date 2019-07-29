﻿using Microsoft.EntityFrameworkCore;
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
                optionsBuilder.UseSqlServer(Connection.CONNECTION_STRING);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Models.Type> Types { get; set; }
    }
}
