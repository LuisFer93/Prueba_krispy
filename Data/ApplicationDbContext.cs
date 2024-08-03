using Microsoft.EntityFrameworkCore;
using Prueba_donas.Models;
using System.Collections.Generic;

namespace Prueba_donas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<VentaDona> VentasDona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VentaDona>(entity =>
            {
                entity.ToTable("VentasDona");
                entity.HasKey(e => e.Id); 
                entity.Property(e => e.Nombre).HasMaxLength(100); 
            });
        }
    }
}
