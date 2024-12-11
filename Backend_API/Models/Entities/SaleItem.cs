namespace Backend_API.Models.Entities
{
    public class SaleItem
    {
        public int SaleItemID { get; set; }
        public string Description { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPriceNet { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? VATRate { get; set; }
        public decimal? VATAmount { get; set; }
        public decimal? GrossAmount { get; set; }
    }
}