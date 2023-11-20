namespace InvoiceApplication.Models.Items
{
    public class VatRate
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
