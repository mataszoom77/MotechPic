using Microsoft.EntityFrameworkCore;
using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Data
{
    public class MotechPicContext : DbContext
    {
        public MotechPicContext(DbContextOptions<MotechPicContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SparePartRequest> SparePartRequests { get; set; }
        public DbSet<ProductRequest> ProductRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product -> SparePart (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.SpareParts)
                .WithOne(sp => sp.Product)
                .HasForeignKey(sp => sp.ProductId);

            // Client -> SparePartRequest (One-to-Many)
            modelBuilder.Entity<Client>()
                .HasMany(cl => cl.SparePartRequests)
                .WithOne(spr => spr.Client)
                .HasForeignKey(spr => spr.ClientId);

            // Client -> ProductRequest (One-to-Many)
            modelBuilder.Entity<Client>()
                .HasMany(p => p.ProductRequests)
                .WithOne(pr => pr.Client)
                .HasForeignKey(pr => pr.ClientID);

        }
    }
}
