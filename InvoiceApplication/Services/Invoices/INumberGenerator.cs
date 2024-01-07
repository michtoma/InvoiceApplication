namespace InvoiceApplication.Services.Invoices
{
    public interface INumberGenerator
    {
        Task<string> GenerateInvoiceNumber(DateTime dateTime);

    }
}
