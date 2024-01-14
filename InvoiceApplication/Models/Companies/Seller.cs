using InvoiceApplication.Models.Invoices;
using InvoiceApplication.Models.Items;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.Models.Companies
{
    public class Seller
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
        public bool IsVatPayer { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; } = new List<Invoice>();
        public AppUser? User { get; set; }
        public string UserId { get; set; }
        public IEnumerable<Buyer> Buyers { get; set; } = new List<Buyer>();
        public IEnumerable<Item> Items { get; set; } = new List<Item>();

    }
}
