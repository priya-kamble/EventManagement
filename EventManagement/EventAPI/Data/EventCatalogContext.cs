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
        public DbSet<Location> Locations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(e =>
            {
                e.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
                e.Property(p => p.Title).IsRequired().HasMaxLength(200);
                e.Property(p => p.Description).HasMaxLength(200);
                e.Property(p => p.Address).HasMaxLength(200);
                e.HasOne(p => p.SubCategory).WithMany().HasForeignKey(p => p.SubCategoryId);
                e.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);
                e.HasOne(p => p.Format).WithMany().HasForeignKey(p => p.FormatId);
                e.HasOne(p => p.Location).WithMany().HasForeignKey(p => p.LocationId);
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

            modelBuilder.Entity<Location>(e =>
            {
                e.Property(l => l.LocationId).IsRequired().ValueGeneratedOnAdd();
                e.Property(l => l.City).IsRequired().HasMaxLength(100);
                e.Property(l => l.State).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Ticket>(e =>
            {
                e.Property(t => t.TicketId).IsRequired().ValueGeneratedOnAdd();
                e.Property(t => t.Price).IsRequired().HasColumnType("decimal(18,2)");
                e.Property(t => t.Quantity).IsRequired();
                e.HasOne(t => t.TicketCategory).WithMany().HasForeignKey(t => t.TicketCategoryId);
                e.HasOne(t => t.Event).WithMany().HasForeignKey(t => t.EventId);
            });

            modelBuilder.Entity<TicketCategory>(e =>
            {
                e.Property(t => t.TicketCategoryId).IsRequired().ValueGeneratedOnAdd();
                e.Property(t => t.CategoryName).IsRequired().HasMaxLength(200);
            });
        }
    }
}
