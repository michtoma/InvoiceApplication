using InvoiceApplication.Models.Invoices;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.Models.Companies
{
    public abstract class Company
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(10), MinLength(10)]
        public string Nip { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();

    }
}
