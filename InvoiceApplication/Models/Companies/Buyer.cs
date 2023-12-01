using InvoiceApplication.Models.Invoices;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.Models.Companies
{
    public class Buyer : Company
    {
        public bool IsActive { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; } = new List<Invoice>();


    }
}
