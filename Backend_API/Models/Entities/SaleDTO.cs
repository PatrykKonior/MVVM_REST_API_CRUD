namespace Backend_API.Models.Entities;

public class SaleDTO
{
    public int SaleID { get; set; }
    public DateTime? SaleDate { get; set; }
    public decimal? TotalNetAmount { get; set; }
    public decimal? TotalVATAmount { get; set; }
    public decimal? TotalGrossAmount { get; set; }
    public string? SaleStatus { get; set; }
    public string? ClientName { get; set; } 
    public string? ClientNIP { get; set; }
    public string? ClientRegon { get; set; }
}