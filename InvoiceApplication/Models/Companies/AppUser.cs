using InvoiceApplication.Models.Invoices;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace InvoiceApplication.Models.Companies
{
    public class AppUser : IdentityUser
    {
        //public string Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Buyer> Buyers { get; set; } = new List<Buyer>();
        public Seller? Seller { get; set; }
        public int SellerId { get; set;}
    }
}
