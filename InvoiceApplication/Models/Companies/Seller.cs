using InvoiceApplication.Models.Invoices;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.Models.Companies
{
    public class Seller : Company
    {
        public bool IsVatPayer { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; } = new List<Invoice>();

    }
}
