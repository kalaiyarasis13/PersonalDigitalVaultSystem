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

        public DbSet<SharedLink> SharedLinks { get; set; }
    }
}