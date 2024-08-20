using Microsoft.EntityFrameworkCore;
using session3.Configrations;
using session3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session3.Data
{
    internal class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Task2;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfigrations());
            modelBuilder.ApplyConfiguration(new OrderConfigration());

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }

    }
}

