using EventAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Data
{
    public class EventCatalogContext : DbContext
    {
        public EventCatalogContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Event> EventCatalog { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Format> Formats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(e =>
            {
                e.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
                e.Property(p => p.Title).IsRequired().HasMaxLength(200);
                e.HasOne(p => p.SubCategory).WithMany().HasForeignKey(p => p.SubCategoryId);
                e.HasOne(p => p.User).WithMany().HasForeignKey(c => c.UserId);
                e.HasOne(p => p.Format).WithMany().HasForeignKey(p => p.FormatId);
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.Property(c => c.CategoryId).IsRequired().ValueGeneratedOnAdd();
                e.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<SubCategory>(e =>
            {
                e.Property(s => s.SubCategoryId).IsRequired().ValueGeneratedOnAdd();
                e.Property(s=> s.SubCategoryName).IsRequired().HasMaxLength(100);
                e.HasOne(s => s.Category).WithMany().HasForeignKey(s => s.CategoryId);
            });

            modelBuilder.Entity<Organization>(e =>
            {
                e.HasKey(o => o.OrganizerId);
                e.Property(o => o.OrganizerId).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<User>(e =>
            {
               e.HasKey(u => u.UserId);
               e.Property(u => u.UserId).IsRequired().HasMaxLength(100);
               e.HasOne(u => u.Organization).WithOne(u => u.User).HasForeignKey<Organization>(U => U.UserId);
            });

            modelBuilder.Entity<Format>(e =>
            {
                e.Property(f => f.FormatId).IsRequired().ValueGeneratedOnAdd();
                e.Property(f => f.FormatName).IsRequired().HasMaxLength(100);
            });
        }
    }
}
