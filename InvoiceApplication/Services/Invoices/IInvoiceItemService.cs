using InvoiceApplication.Models.Invoices;

namespace InvoiceApplication.Services.Invoices
{
    public interface IInvoiceItemService
    {
        Task<List<InvoiceItems>> GetAllInvoiceItemsAsync();
        Task AddInvoiceItemAsync(InvoiceItems invoiceItem);
        Task UpdateInvoiceItemAsync(InvoiceItems invoiceItem);
        Task<InvoiceItems> GetInvoiceItemByIdAsync(int invoiceItemId);
        Task DeleteInvoiceItemByIdAsync(int invoicesItemId);
    }
}
