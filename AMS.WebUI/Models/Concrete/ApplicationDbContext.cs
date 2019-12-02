using System;
using Microsoft.EntityFrameworkCore;

namespace AMS.WebUI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FacilityCost> FacilityCosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacilityCost>().Property(fc => fc.Title)
                .HasMaxLength(100);

            modelBuilder.Entity<FacilityCost>().Property(fc => fc.EmptyUnitShare)
                .HasColumnType("decimal(3,2)");

            modelBuilder.Entity<Unit>().Property(fc => fc.Name)
                .HasMaxLength(100);
        }
    }
}
