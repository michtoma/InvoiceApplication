﻿using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using InvoiceApplication.Models.Invoices;
using InvoiceApplication.Services.Companies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace InvoiceApplication.Services.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly IAppUserService _userService;


        public InvoiceService(IDbContextFactory<AppDbContext> contextFactory, IAppUserService userService)
        {
            _contextFactory = contextFactory;
            _userService = userService;
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var invoices = await GetUSerInvoicesAsync();
            

            Invoice numberExist =invoices.FirstOrDefault(i => i.Number.ToLower() == invoice.Number.ToLower());
            if (numberExist != null)
            {
                throw new InvalidOperationException("Invoice with this Number allready exist !!!");
            }
            else
            {
               
                await context.AddAsync(invoice);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteInvoiceAsync(Invoice invoice)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Invoice.Remove(invoice);
            await context.SaveChangesAsync();
        }

        public async Task<List<Invoice>> GetAllInvoiceAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Invoice.Include(i => i.InvoiceItems).ThenInclude(ii => ii.Item).ThenInclude(it => it.UnitOfMeasure).ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var invoice = await context.Invoice.Include(i=>i.InvoiceItems).ThenInclude(ii=>ii.Item).ThenInclude(it=>it.UnitOfMeasure)
                .Include(i=>i.BuyerAddress).Include(i=>i.SellerAddress).Include(i=>i.Buyer).ThenInclude(b=>b.Address).Include(i=>i.Seller).ThenInclude(s=>s.Address).FirstOrDefaultAsync(i=> i.Id == id);

            if (invoice != null)
            {
                return invoice;

            }
            else
            {
                throw new InvalidOperationException("Invoice not found");
            }
        }

        public async Task<List<Invoice>> GetUSerInvoicesAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var user = await _userService.GetCurrentUser();
            return await context.Invoice.Where(i=>i.AppUserId == user.Id).Include(i => i.InvoiceItems).ThenInclude(ii => ii.Item).ThenInclude(it => it.UnitOfMeasure).Include(i => i.BuyerAddress).Include(i => i.SellerAddress).ToListAsync();
        }

        public async Task<bool> InvoiceExist(int invoiceId)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var invoice = await context.Invoice.FindAsync(invoiceId);
            return invoice != null;
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var oldInvoice = context.Invoice.Find(invoice.Id);
            if (oldInvoice != null)
            {
                oldInvoice.InvoiceItems = invoice.InvoiceItems;
                oldInvoice.Number = invoice.Number;
                oldInvoice.CreateDate = invoice.CreateDate;
                oldInvoice.DaysOfPaiment = invoice.DaysOfPaiment;
                oldInvoice.Description = invoice.Description;
                oldInvoice.IsPaid = invoice.IsPaid;
                oldInvoice.SellerAddressId = invoice.SellerAddressId;
                oldInvoice.BuyerAddressId = invoice.BuyerAddressId;
                context.Update(oldInvoice);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Invoice not found");
            }
        }
    }
}
