using InvoiceApplication.Models.Items;

namespace InvoiceApplication.Services.Items
{
    public interface IItemService
    {
        Task<List<Item>> GetAllItemsAsync();
        Task<List<Item>> GetUSerItemsAsync();
        Task AddNewItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Item item);
        Task<Item> GetItemByIdAsync(int id);
    }
}
