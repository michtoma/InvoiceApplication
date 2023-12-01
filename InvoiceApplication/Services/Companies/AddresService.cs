using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Companies
{
    public class AddresService : IAddresService
    {
        private readonly AppDbContext _context;

        public AddresService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAddressAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddressAsync(int addressId)
        {
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

        public async Task<Address> GetAddressByIdAsync(int addressId)
        {
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
            return await _context.Addresses.ToListAsync();
        }

        public async Task UpdateAddressAsync(Address address)
        {
            try
            {
                var existingAddress = await GetAddressByIdAsync(address.Id);

                if (existingAddress != null)
                {
                    existingAddress.Street = address.Street;
                    existingAddress.City = address.City;
                    existingAddress.PostalCode = address.PostalCode;
                    existingAddress.Companies = address.Companies;
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
