using Microsoft.EntityFrameworkCore;
using PersonalDigitalVaultSystem.Models;
using System;

namespace PersonalDigitalVaultSystem.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options) { }

        public DbSet<PaymentTransaction> PaymentTransactions => Set<PaymentTransaction>();
        public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
        public DbSet<Feedback> Feedbacks => Set<Feedback>();

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
        
        
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasIndex(u => u.Username).IsUnique();
                entity.HasIndex(u => u.Email).IsUnique();
            });
             
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasOne(f => f.User)
                      .WithMany(u => u.Feedbacks)
                      .HasForeignKey(f => f.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
