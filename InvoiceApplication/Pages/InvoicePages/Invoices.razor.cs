using InvoiceApplication.Models.Invoices;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace InvoiceApplication.Pages.InvoicePages
{

    public partial class Invoices
    {

        bool isVisible = false;
        private List<Invoice> invoices = new();
        PaginationState paginationState = new PaginationState { ItemsPerPage = 5 };
        protected override async Task OnInitializedAsync()
        {
            invoices = await _invoiceService.GetAllInvoiceAsync();
        }
        private void EditInvoice(int InvoiceId)
        {
            navigationManager.NavigateTo($"invoiceAction/{InvoiceId}");
        }
        private void ShowInvoiceDetails(int InvoiceId)
        {
            navigationManager.NavigateTo($"invoice/{InvoiceId}");
        }
        private async void DeleteInvoice(int InvoiceId)
        {
            var invoiceToDelete = await _invoiceService.GetInvoiceByIdAsync(InvoiceId);
            await _invoiceService.DeleteInvoiceAsync(invoiceToDelete);
            invoices = await _invoiceService.GetAllInvoiceAsync();
            StateHasChanged();
        }
    }
}
