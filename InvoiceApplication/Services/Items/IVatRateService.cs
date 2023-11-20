using InvoiceApplication.Models.Items;

namespace InvoiceApplication.Services.Items
{
    public interface IVatRateService
    {
        Task<List<VatRate>> GetVatRatesAsync();
    }
}
