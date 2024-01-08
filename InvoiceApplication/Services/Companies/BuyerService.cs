using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Companies
{
    public class BuyerService : IBuyerService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactoy;
        private readonly IAppUserService _userService;

        public BuyerService(IDbContextFactory<AppDbContext> contextFactoy, IAppUserService userService)
        {
            _contextFactoy = contextFactoy;
            _userService = userService;
        }

        public async Task CreateBuyerAsync(Buyer buyer)
        {
            using var context = _contextFactoy.CreateDbContext();
            context.Buyers.Add(buyer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBuyerAsync(int buyerId)
        {
            using var context = _contextFactoy.CreateDbContext();
            try
            {
                var buyerToDelete = await GetBuyerByIdAsync(buyerId);
                context.Buyers.Remove(buyerToDelete);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error, can't delete Buyer with id: {buyerId} details: {ex.Message}");
            }
        }

        public async Task<Buyer> GetBuyerByIdAsync(int buyerId)
        {
            using var context = _contextFactoy.CreateDbContext();
            try
            {
                return await context.Buyers.Include(b=>b.Address).FirstOrDefaultAsync(b=>b.Id==buyerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Buyer by Id: {ex.Message}");
                throw;
            }
        }


        public async Task<List<Buyer>> GetAllBuyersAsync()
        {
            using var context = _contextFactoy.CreateDbContext();
            return await context.Buyers.ToListAsync();
        }
        public async Task<List<Buyer>> GetUserBuyersAsync()
        {
            using var context = _contextFactoy.CreateDbContext();
            var user =await _userService.GetCurrentUser();
            return await context.Buyers.Where(b=> b.SellerId==user.Seller.Id).Include(b=>b.Address).ToListAsync();
        }

        public async Task UpdateBuyerAsync(Buyer buyer)
        {
            using var context = _contextFactoy.CreateDbContext();
            try
            {
                var existingBuyer = await GetBuyerByIdAsync(buyer.Id);

                if (existingBuyer != null)
                {
                    existingBuyer.AddressId = buyer.AddressId;
                    existingBuyer.Nip = buyer.Nip;
                    existingBuyer.Invoices = buyer.Invoices;
                    existingBuyer.Email = buyer.Email;
                    existingBuyer.IsActive = buyer.IsActive;
                    existingBuyer.Name = buyer.Name;
                    existingBuyer.Phone = buyer.Phone;
                    existingBuyer.SellerId = buyer.SellerId;
                    context.Update(existingBuyer);
                    await context.SaveChangesAsync();
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

