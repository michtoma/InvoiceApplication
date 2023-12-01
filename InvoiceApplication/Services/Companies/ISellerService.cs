using InvoiceApplication.Models.Companies;

namespace InvoiceApplication.Services.Companies
{
    public interface ISellerService
    {
        Task<List<Seller>> GetAllSellersAsync();
        Task<Seller> GetSellerByIdAsync(int sellerId);
        Task CreateSellerAsync(Seller seller);
        Task DeleteSellerAsync(int sellerId);
        Task UpdateSellerAsync(Seller seller);

    }
}
