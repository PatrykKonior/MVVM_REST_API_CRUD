namespace Backend_API.Models.Entities
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int? SaleID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public string InvoiceStatus { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}