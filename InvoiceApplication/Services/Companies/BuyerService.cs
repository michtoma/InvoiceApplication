using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Companies
{
    public class BuyerService : IBuyerService
    {
        private readonly AppDbContext _context;

        public BuyerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBuyerAsync(Buyer buyer)
        {
            _context.Buyers.Add(buyer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBuyerAsync(int buyerId)
        {
            try
            {
                var BuyerToDelete = await GetBuyerByIdAsync(buyerId);
                _context.Buyers.Remove(BuyerToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error, can't delete Buyer with id: {buyerId} details: {ex.Message}");
            }
        }

        public async Task<Buyer> GetBuyerByIdAsync(int buyerId)
        {
            try
            {
                return await _context.Buyers.FindAsync(buyerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Buyer by Id: {ex.Message}");
                throw;
            }
        }


        public async Task<List<Buyer>> GetAllBuyersAsync()
        {
            return await _context.Buyers.ToListAsync();
        }

        public async Task UpdateBuyerAsync(Buyer buyer)
        {
            try
            {
                var existingBuyer = await GetBuyerByIdAsync(buyer.Id);

                if (existingBuyer != null)
                {
                    existingBuyer.Addresses = buyer.Addresses;
                    existingBuyer.Nip = buyer.Nip;
                    existingBuyer.Invoices = buyer.Invoices;
                    existingBuyer.Email = buyer.Email;
                    existingBuyer.IsActive = buyer.IsActive;
                    existingBuyer.Name = buyer.Name;
                    existingBuyer.Phone = buyer.Phone;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException($"Buyer with Id {buyer.Id} not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Buyer: {ex.Message}");
                throw;
            }

        }
    }
}

