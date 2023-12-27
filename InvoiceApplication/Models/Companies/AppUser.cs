using InvoiceApplication.Models.Invoices;
using Microsoft.AspNetCore.Identity;

namespace InvoiceApplication.Models.Companies
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
