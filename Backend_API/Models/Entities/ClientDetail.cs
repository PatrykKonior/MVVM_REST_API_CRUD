namespace Backend_API.Models.Entities
{
    public class ClientDetail
    {
        public int ClientDetailID { get; set; }
        public int ClientID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}