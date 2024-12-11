namespace Backend_API.Models.Entities
{
    public class Contract
    {
        public int ContractID { get; set; }
        public int? ProjectID { get; set; }
        public DateTime? ContractDate { get; set; }
        public decimal? ContractValueNet { get; set; }
        public decimal? VATRate { get; set; }
        public decimal? ContractValueGross { get; set; }
        public DateTime? ClientSignatureDate { get; set; }
        public DateTime? CompanySignatureDate { get; set; }
    }
}