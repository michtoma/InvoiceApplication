﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvoiceApplication.Models.Items;

namespace InvoiceApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<VatRate> VatRate { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
    }
}
