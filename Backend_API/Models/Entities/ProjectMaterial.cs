namespace Backend_API.Models.Entities
{
    public class ProjectMaterial
    {
        public int ProjectMaterialID { get; set; }
        public int? ProjectID { get; set; }
        public int? MaterialID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? VATAmount { get; set; }
    }
}