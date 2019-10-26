using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSW.BlockChain.Models
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                        .HasMany(c => c.CardSalesEntries)
                        .WithOne()
                        .IsRequired();
        }

        public DbSet<Card> CardEntries { get; set; }

        public DbSet<CardSalesEntry> CardSalesEntries { get; set; }
    }
}
