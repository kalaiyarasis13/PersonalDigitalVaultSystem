using Microsoft.EntityFrameworkCore;
using PersonalDigitalVaultSystem.Models;
using System.Collections.Generic;

namespace PersonalDigitalVaultSystem.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options)
            : base(options)
        {
        }

        public DbSet<SharedLink> SharedLinks => Set<SharedLink>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SharedLink>(entity =>
            {
                entity.HasIndex(s => s.Token).IsUnique();

                entity.HasOne(s => s.User)
                      .WithMany(u => u.SharedLinks)
                      .HasForeignKey(s => s.UserId)
                      .OnDelete(DeleteBehavior.Restrict); 

                entity.HasOne(s => s.Document)
                      .WithMany()
                      .HasForeignKey(s => s.DocumentId)
                      .OnDelete(DeleteBehavior.Cascade); 
            });
        }
    }
}