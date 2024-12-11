namespace Backend_API.Models.Entities
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int? ClientID { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? TotalNetAmount { get; set; }
        public decimal? TotalVATAmount { get; set; }
        public decimal? TotalGrossAmount { get; set; }
        public string SaleStatus { get; set; }
    }
}