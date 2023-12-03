using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace InvoiceApplication.Services.Companies
{
    public class AddresService : IAddresService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactoy;

        public AddresService(IDbContextFactory<AppDbContext> contextFactoy)
        {
            _contextFactoy = contextFactoy;
        }

        public async Task CreateAddressAsync(Address address)
        {
            using var _context = _contextFactoy.CreateDbContext();
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddressAsync(int addressId)
        {
            using var _context = _contextFactoy.CreateDbContext();
            try
            {
                var addressToDelete = await GetAddressByIdAsync(addressId);
                _context.Addresses.Remove(addressToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error, can't delete Address with id: {addressId} details: {ex.Message}");
            }
        }

        public async Task<List<Address>> GetAddressByCompanyIdAsync(int companyId)
        {
            using var _context = _contextFactoy.CreateDbContext();
            return await _context.Addresses.Where(a=>a.CompanyId == companyId).ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int addressId)
        {
            using var _context = _contextFactoy.CreateDbContext();
            try
            {
                return await _context.Addresses.FindAsync(addressId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Address by Id: {ex.Message}");
                throw;
            }
        }
    

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            using var _context = _contextFactoy.CreateDbContext();
            return await _context.Addresses.ToListAsync();
        }

        public async Task UpdateAddressAsync(Address address)
        {
            using var _context = _contextFactoy.CreateDbContext();
            try
            {
                var existingAddress = await GetAddressByIdAsync(address.Id);

                if (existingAddress != null)
                {
                    existingAddress.Street = address.Street;
                    existingAddress.City = address.City;
                    existingAddress.PostalCode = address.PostalCode;
                    existingAddress.CompanyId = address.CompanyId;
                    existingAddress.Country = address.Country;
                    existingAddress.IsActive = address.IsActive;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException($"Address with Id {address.Id} not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Address: {ex.Message}");
                throw;
            }

        }
    }
}
