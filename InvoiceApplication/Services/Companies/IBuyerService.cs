using InvoiceApplication.Models.Companies;

namespace InvoiceApplication.Services.Companies
{
    public interface IBuyerService
    {
        Task<List<Buyer>> GetAllBuyersAsync();
        Task<Buyer> GetBuyerByIdAsync(int buyerId);
        Task CreateBuyerAsync(Buyer buyer);
        Task DeleteBuyerAsync(int buyerId);
        Task UpdateBuyerAsync(Buyer buyer);
    }
}
