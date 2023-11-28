using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApplication.Models.Items
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Ean { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        [Required(ErrorMessage = "Price is required")]
        public double NetPrice { get; set; } = 0;
        public double Quantity { get; set; } = 0;
        public VatRate? VatRate { get; set; }
        public int VatRateID { get; set; } = 1;
        public UnitOfMeasure? UnitOfMeasure { get; set; }
        public int UnitOfMeasureId { get; set; } = 1;
        [NotMapped]
        public double GrossPrice
        {
            get
            {
                if (VatRate == null) return 0;
                return NetPrice * VatRate.Rate / 100 + NetPrice;
            }
        }
        [NotMapped]
        public double TotalNetValue
        {
            get
            {
                return NetPrice * Quantity;
            }
        }
        [NotMapped]
        public double TotalGrossValue
        {
            get
            {
                if (VatRate == null) return 0;
                return TotalNetValue * VatRate.Rate / 100 + TotalNetValue;
            }
        }
        public void SetNetPriceByGross(double grossPrice)
        {
            if (VatRate != null)
            {
                if (VatRate.Rate == 0) NetPrice = grossPrice;
                else
                {
                    NetPrice = grossPrice / VatRate.Rate / 100;
                }
            }
        }
    }
}
