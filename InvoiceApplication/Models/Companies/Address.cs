using System.Reflection;

namespace InvoiceApplication.Models.Companies
{
    public class Address 
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; } 
        public string Country { get; set; }
        public IEnumerable<Company> Companies { get; set; } = new List<Company>();
        public bool IsActive { get; set; }
    }
}
