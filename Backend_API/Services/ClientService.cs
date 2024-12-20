using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class ClientService
    {
        private readonly DesignOfficeDbContext _context;

        public ClientService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.Select(client => new Client
            {
                ClientID = client.ClientID,
                CompanyName = client.CompanyName ?? string.Empty,
                NIP = client.NIP ?? string.Empty,
                Regon = client.Regon ?? string.Empty,
                PhoneNumber = client.PhoneNumber ?? string.Empty,
                Email = client.Email ?? string.Empty,
                ContactPersonName = client.ContactPersonName ?? string.Empty
            }).ToList();
        }

        public Client GetById(int id)
        {
            return _context.Clients.Find(id);
        }

        public void Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public bool Update(Client client)
        {
            var existingClient = _context.Clients.Find(client.ClientID);
            if (existingClient == null)
                return false;

            existingClient.CompanyName = client.CompanyName;
            existingClient.NIP = client.NIP;
            existingClient.Regon = client.Regon;
            existingClient.PhoneNumber = client.PhoneNumber; 
            existingClient.Email = client.Email;             
            existingClient.ContactPersonName = client.ContactPersonName; 
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
                return false;

            _context.Clients.Remove(client);
            _context.SaveChanges();
            return true;
        }
    }
}