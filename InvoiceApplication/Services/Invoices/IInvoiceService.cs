using InvoiceApplication.Models.Invoices;

namespace InvoiceApplication.Services.Invoices
{
    public interface IInvoiceService
    {
        Task<List<Models.Invoices.Invoice>> GetAllInvoiceAsync();
        Task<List<Models.Invoices.Invoice>> GetUSerInvoicesAsync();
        Task<Models.Invoices.Invoice> GetInvoiceByIdAsync(int id);
        Task UpdateInvoiceAsync(Models.Invoices.Invoice invoice);
        Task DeleteInvoiceAsync(Models.Invoices.Invoice invoice);
        Task AddInvoiceAsync(Models.Invoices.Invoice invoice);
        Task<bool> InvoiceExist(int invoiceId);
        Task FinalizeInvoice(Invoice Invoice);
    }
}
