using InvoiceApplication.Models.Invoices;

namespace InvoiceApplication.Pages
{
   
    public partial class Invoices
    {
       
        bool isVisible = false;
        private List<Invoice> invoices = new();
        protected override async Task OnInitializedAsync()
        {
            invoices = await _invoiceService.GetAllInvoiceAsync();
        }
    }
}
