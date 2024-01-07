using InvoiceApplication.Data;
using InvoiceApplication.Models.Items;
using InvoiceApplication.Pages;
using InvoiceApplication.Services.Companies;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactoy;
        private readonly IAppUserService _userService;

        public ItemService(IDbContextFactory<AppDbContext> contextFactoy, IAppUserService userService)
        {
            _contextFactoy = contextFactoy;
            _userService = userService;
        }

        public async Task AddNewItemAsync(Item item)
        {
            using var _context = _contextFactoy.CreateDbContext();

            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(Item item)
        {
            using var _context = _contextFactoy.CreateDbContext();

            _context.Remove(item);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            using var _context = _contextFactoy.CreateDbContext();

            return await _context.Item.Include(v => v.VatRate).Include(i=>i.UnitOfMeasure).ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            using var _context = _contextFactoy.CreateDbContext();


            var item = await _context.Item.FindAsync(id);

            if (item != null)
            {
                return item;

            }
            else
            {
                throw new InvalidOperationException("Item not found");
            }
        }

        public async Task<List<Item>> GetUSerItemsAsync()
        {
            using var _context = _contextFactoy.CreateDbContext();
            var user =await _userService.GetCurrentUser();

            return await _context.Item.Where(i=>i.SellerId==user.Seller.Id).Include(v => v.VatRate).Include(i => i.UnitOfMeasure).ToListAsync();

        }

        public async Task UpdateItemAsync(Item item)
        {
            using var _context = _contextFactoy.CreateDbContext();

            var existingItem = await _context.Item.FindAsync(item.Id);

            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
                existingItem.Ean = item.Ean;
                existingItem.Comments = item.Comments;
                existingItem.NetPrice = item.NetPrice;
                existingItem.VatRateID = item.VatRateID;
                existingItem.Quantity = item.Quantity;
                existingItem.UnitOfMeasureId = item.UnitOfMeasureId;

                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the item with the specified id is not found.
                throw new InvalidOperationException("Item not found");
            }
        }
    }
}
