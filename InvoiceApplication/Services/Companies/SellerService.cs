using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Companies
{
    public class SellerService : ISellerService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public SellerService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateSellerAsync(Seller seller)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSellerAsync(int sellerId)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            try
            {
                var SellerToDelete = await GetSellerByIdAsync(sellerId);
                _context.Sellers.Remove(SellerToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error, can't delete Seller with id: {sellerId} details: {ex.Message}");
            }
        }

        public async Task<Seller> GetSellerByIdAsync(int sellerId)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            try
            {
                return await _context.Sellers.FindAsync(sellerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Seller by Id: {ex.Message}");
                throw;
            }
        }


        public async Task<List<Seller>> GetAllSellersAsync()
        {
            using var _context = _dbContextFactory.CreateDbContext();
            return await _context.Sellers.ToListAsync();
        }

        public async Task UpdateSellerAsync(Seller seller)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            try
            {
                var existingSeller = await GetSellerByIdAsync(seller.Id);

                if (existingSeller != null)
                {
                    existingSeller.AddressId = seller.AddressId;
                    existingSeller.Nip = seller.Nip;
                    existingSeller.Invoices = seller.Invoices;
                    existingSeller.Email = seller.Email;
                    existingSeller.IsVatPayer = seller.IsVatPayer;
                    existingSeller.Name = seller.Name;
                    existingSeller.Phone = seller.Phone;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException($"Seller with Id {seller.Id} not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Seller: {ex.Message}");
                throw;
            }

        }
    }

}
