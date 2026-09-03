using Microsoft.EntityFrameworkCore;
using PersonalDigitalVaultSystem.Models;
using System;

namespace PersonalDigitalVaultSystem.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options) { }

        public DbSet<PaymentTransaction> PaymentTransactions => Set<PaymentTransaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PaymentTransaction>(entity =>
            {
                entity.HasOne(p => p.User)
                      .WithMany(u => u.paymentTransactions)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
        }
}
