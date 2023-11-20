using InvoiceApplication.Models.Items;

namespace InvoiceApplication.Services.Items
{
    public interface IItemService
    {
        Task<List<Item>> GetAllItems();
        Task AddNewItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(Item item);
        Task<Item> GetItemById(int id);
    }
}
