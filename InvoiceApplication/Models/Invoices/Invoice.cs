using InvoiceApplication.Models.Companies;

namespace InvoiceApplication.Models.Invoices
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Buyer? Buyer { get; set; }
        public int? BuyerId { get; set; }
        public Seller? Seller { get; set; }
        public int? SellerId { get; set; }
        public Address? SellerAddress { get; set; }
        public int? SellerAddressId { get; set; }
        public Address? BuyerAddress { get; set; }
        public int? BuyerAddressId { get; set; }
        public string AppUserId { get; set; }
        public int DaysOfPaiment { get; set; }
        public DateTime PaymentDate
        {
            get
            {
                return CreateDate.AddDays(DaysOfPaiment);
            }
        }
        public bool IsPaid { get; set; } = false;
        public bool IsEditable { get; set; } = true;
        public string Description { get; set; } = string.Empty;
        public List<InvoiceItems> InvoiceItems { get; set; } = new List<InvoiceItems>();
        public double TotaNetlValue
        {
            get
            {
                return InvoiceItems.Sum(i => i.TotalNetValue);
            }
        }
        public double TotalGrossValue
        {
            get
            {
                return InvoiceItems.Sum(i => i.TotalGrossValue);
            }
        }
    }
}
