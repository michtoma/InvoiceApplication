﻿using InvoiceApplication.Models.Items;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApplication.Models.Invoices
{
    public class InvoiceItems
    {
        public int Id { get; set; }
        public Item? Item { get; set; }
        public int ItemId { get; set; }
        public Invoice? Invoice { get; set; }
        public int InvoiceId { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Quantity { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double NetPrice { get; set; } = 0;
        public int VatRate { get; set; } = 0;
        [NotMapped]
        public double GrossPrice
        {
            get
            {
                return NetPrice * VatRate / 100 + NetPrice;
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
                return TotalNetValue * VatRate / 100 + TotalNetValue;
            }
        }
    }
}

