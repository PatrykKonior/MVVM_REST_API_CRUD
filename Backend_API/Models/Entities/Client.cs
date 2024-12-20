namespace Backend_API.Models.Entities
{
    public class Client
    {
        public int ClientID { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ContactPersonName { get; set; }
    }
}