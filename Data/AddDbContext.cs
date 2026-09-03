using Microsoft.EntityFrameworkCore;
using PersonalDigitalVaultSystem.Models;
using System;

namespace PersonalDigitalVaultSystem.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options) { }

        public DbSet<FolderCategory> Folders => Set<FolderCategory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FolderCategory>(entity =>
            {
                entity.HasOne(f => f.User)
                      .WithMany(u => u.Folders)
                      .HasForeignKey(f => f.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(f => f.ParentFolder)
                      .WithMany(f => f.SubFolders)
                      .HasForeignKey(f => f.ParentFolderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
