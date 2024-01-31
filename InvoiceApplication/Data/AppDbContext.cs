using InvoiceApplication.Models.Companies;
using InvoiceApplication.Models.Invoices;
using InvoiceApplication.Models.Items;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Data
{
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<VatRate> VatRate { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>().HasOne(a => a.Seller).WithOne(s => s.User).HasForeignKey<Seller>(s => s.UserId);
            builder.Entity<Item>()
                    .HasOne(i => i.Seller)
                    .WithMany(s => s.Items)
                    .HasForeignKey(s => s.SellerId);
            builder.Entity<Address>().HasOne(a => a.Buyer).WithOne(b => b.Address).HasForeignKey<Buyer>(b => b.AddressId);
            builder.Entity<Address>().HasOne(a => a.Seller).WithOne(b => b.Address).HasForeignKey<Seller>(b => b.AddressId);
            base.OnModelCreating(builder);
        }
    }
}
