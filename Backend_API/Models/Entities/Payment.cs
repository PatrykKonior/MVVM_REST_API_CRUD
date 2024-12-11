namespace Backend_API.Models.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int? InvoiceID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
    }
}