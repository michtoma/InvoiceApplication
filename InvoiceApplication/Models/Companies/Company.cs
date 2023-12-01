using InvoiceApplication.Models.Invoices;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.Models.Companies
{
    public abstract class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Nip { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();

    }
}
