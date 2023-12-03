﻿using InvoiceApplication.Data;
using InvoiceApplication.Models.Invoices;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Invoices
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        

        public InvoiceItemService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddInvoiceItemAsync(InvoiceItems invoiceItem)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            try
            {
                await _context.AddAsync(invoiceItem);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding InvoiceItem to db:{ex.Message}");
            }
        }

        public async Task DeleteInvoiceItemByIdAsync(int invoicesItemId)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            var invoiceItemToDelete = await GetInvoiceItemByIdAsync(invoicesItemId);
            try
            {
                _context.Remove(invoiceItemToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting InvoiceItem by Id: {ex.Message}");
                throw;
            }
        }

        public async Task<List<InvoiceItems>> GetAllInvoiceItemsAsync()
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            return await _context.InvoiceItems.Include(i => i.Item).ToListAsync();
        }

        public async Task<InvoiceItems> GetInvoiceItemByIdAsync(int invoiceItemId)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            try
            {
                return await _context.InvoiceItems.FindAsync(invoiceItemId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting InvoiceItem by Id: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateInvoiceItemAsync(InvoiceItems invoiceItem)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            try
            {
                var existingInvoiceItem = await _context.InvoiceItems.FindAsync(invoiceItem.Id);

                if (existingInvoiceItem != null)
                {
                    existingInvoiceItem.ItemId = invoiceItem.ItemId;
                    existingInvoiceItem.InvoiceId = invoiceItem.InvoiceId;
                    existingInvoiceItem.Quantity = invoiceItem.Quantity;
                    existingInvoiceItem.NetPrice = invoiceItem.NetPrice;
                    existingInvoiceItem.VatRate = invoiceItem.VatRate;
                    existingInvoiceItem.Description = invoiceItem.Description;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException($"InvoiceItem with Id {invoiceItem.Id} not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating InvoiceItem: {ex.Message}");
                throw;
            }
        }

    }
}
