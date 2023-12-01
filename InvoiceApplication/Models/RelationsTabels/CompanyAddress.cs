using InvoiceApplication.Models.Companies;
using InvoiceApplication.Models.Invoices;

namespace InvoiceApplication.Models.RelationsTabels
{
    public class CompanyAddress
    {
        public Company? Company { get; set; }
        public int CompanyId { get; set; }
        public Invoice? Invoice { get; set; }
        public int InvoiceId { get; set; }
    }
}
