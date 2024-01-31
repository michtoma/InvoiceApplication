using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using Microsoft.EntityFrameworkCore;

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
            using var context = _contextFactoy.CreateDbContext();
            context.Addresses.Add(address);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAddressAsync(int addressId)
        {
            using var context = _contextFactoy.CreateDbContext();
            try
            {
                var addressToDelete = await GetAddressByIdAsync(addressId);
                context.Addresses.Remove(addressToDelete);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error, can't delete Address with id: {addressId} details: {ex.Message}");
            }
        }

        public async Task<List<Address>> GetAddressByBuyerIdAsync(int companyId)
        {
            using var context = _contextFactoy.CreateDbContext();
            return await context.Addresses.Where(a => a.BuyerId == companyId).ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int addressId)
        {
            using var context = _contextFactoy.CreateDbContext();
            try
            {
                return await context.Addresses.FindAsync(addressId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Address by Id: {ex.Message}");
                throw;
            }
        }


        public async Task<List<Address>> GetAllAddressesAsync()
        {
            using var context = _contextFactoy.CreateDbContext();
            return await context.Addresses.ToListAsync();
        }

        public async Task UpdateAddressAsync(Address address)
        {
            using var context = _contextFactoy.CreateDbContext();
            try
            {
                var existingAddress = await GetAddressByIdAsync(address.Id);

                if (existingAddress != null)
                {
                    context.Update(address);
                    await context.SaveChangesAsync();
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
