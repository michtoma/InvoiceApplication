﻿using InvoiceApplication.Data;
using InvoiceApplication.Models.Invoices;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly AppDbContext _context;

        public InvoiceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            var invoices = await GetAllInvoiceAsync();
            Invoice numberExist = invoices.FirstOrDefault(i => i.Number.ToLower() == invoice.Number.ToLower());
            if (numberExist != null)
            {
                throw new InvalidOperationException("Invoice with this Number allready exist !!!");
            }
            else
            {
                await _context.AddAsync(invoice);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteInvoiceAsync(Invoice invoice)
        {
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Invoice>> GetAllInvoiceAsync()
        {
            return await _context.Invoice.Include(i=>i.InvoiceItems).ThenInclude(ii=>ii.Item).ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _context.Invoice.Include(i => i.InvoiceItems).ThenInclude(i=>i.Item).ThenInclude(i=>i.UnitOfMeasure).FirstOrDefaultAsync(i=> i.Id == id);

            if (invoice != null)
            {
                return invoice;

            }
            else
            {
                throw new InvalidOperationException("Invoice not found");
            }
        }

        public async Task<bool> InvoiceExist(int invoiceId)
        {
            var invoice = await _context.Invoice.FindAsync(invoiceId);
            return invoice != null;
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            var oldInvoice = _context.Invoice.Find(invoice.Id);
            if (oldInvoice != null)
            {
                oldInvoice.InvoiceItems = invoice.InvoiceItems;
                oldInvoice.Number = invoice.Number;
                oldInvoice.DateOfIssue = invoice.DateOfIssue;
                oldInvoice.CreateDate = invoice.CreateDate;
                oldInvoice.DaysOfPaiment = invoice.DaysOfPaiment;
                oldInvoice.Description = invoice.Description;
                oldInvoice.IsPaid = invoice.IsPaid;
                oldInvoice.SellerAddressId = invoice.SellerAddressId;
                oldInvoice.BuyerAddressId = invoice.BuyerAddressId;
                _context.Update(oldInvoice);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Invoice not found");
            }
        }
    }
}
