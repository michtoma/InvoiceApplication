using InvoiceApplication.Models.Invoices;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.Models.Companies
{
    public class Buyer
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
        public Address? Address { get; set; }
        public int? AddressId { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; } = Enumerable.Empty<Invoice>();
        public Seller? Seller { get; set; }
        public int? SellerId { get; set; }   

    }
}
