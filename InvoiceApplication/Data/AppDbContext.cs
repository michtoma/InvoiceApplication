using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvoiceApplication.Models.Items;
using InvoiceApplication.Models.Invoices;
using InvoiceApplication.Models.Companies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InvoiceApplication.Data
{
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext (DbContextOptions options)
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
