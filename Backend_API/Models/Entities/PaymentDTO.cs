namespace Backend_API.Models.Entities;

public class PaymentDTO
{
    public int PaymentID { get; set; }
    public DateTime? PaymentDate { get; set; }
    public decimal? PaymentAmount { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime? InvoiceDate { get; set; } // Z Invoice
    public string? InvoiceStatus { get; set; } // Z Invoice
    public decimal? TotalAmount { get; set; } // Z Invoice
}