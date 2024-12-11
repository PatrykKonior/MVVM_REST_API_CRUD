namespace Backend_API.Models.Entities
{
    public class Material
    {
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public string MaterialDescription { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? VATRate { get; set; }
    }
}