using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace InvoiceApplication.Models.Companies
{
    public class Address 
    {
        public int Id { get; set; }
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Street { get; set; } = string.Empty;
        [Required]
        public string PostalCode { get; set; } =string.Empty;
        [Required]
        public string StreetNumber {  get; set; } = string.Empty;
        [Required]
        public string ApartmentNumber {  get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = "Polska";
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
