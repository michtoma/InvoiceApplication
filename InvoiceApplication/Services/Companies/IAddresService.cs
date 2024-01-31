using InvoiceApplication.Models.Companies;

namespace InvoiceApplication.Services.Companies
{
    public interface IAddresService
    {
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int addressId);
        Task CreateAddressAsync(Address address);
        Task DeleteAddressAsync(int addressId);
        Task UpdateAddressAsync(Address address);
        Task<List<Address>> GetAddressByBuyerIdAsync(int companyId);
    }
}
