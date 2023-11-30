﻿namespace InvoiceApplication.Models.Invoices
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
        public int DaysOfPaiment { get; set; }
        public DateTime PaymentDate
        {
            get
            {
              return DateOfIssue.AddDays(DaysOfPaiment);
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