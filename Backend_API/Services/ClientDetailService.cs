using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class ClientDetailsService
    {
        private readonly DesignOfficeDbContext _context;

        public ClientDetailsService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ClientDetail> GetAll()
        {
            return _context.ClientDetails.ToList();
        }

        public ClientDetail GetById(int id)
        {
            return _context.ClientDetails.Find(id);
        }

        public void Create(ClientDetail clientDetail)
        {
            _context.ClientDetails.Add(clientDetail);
            _context.SaveChanges();
        }

        public bool Update(ClientDetail clientDetail)
        {
            var existingDetail = _context.ClientDetails.Find(clientDetail.ClientDetailID);
            if (existingDetail == null)
                return false;

            existingDetail.ClientID = clientDetail.ClientID;
            existingDetail.Address = clientDetail.Address;
            existingDetail.City = clientDetail.City;
            existingDetail.PostalCode = clientDetail.PostalCode;
            existingDetail.Country = clientDetail.Country;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var clientDetail = _context.ClientDetails.Find(id);
            if (clientDetail == null)
                return false;

            _context.ClientDetails.Remove(clientDetail);
            _context.SaveChanges();
            return true;
        }
    }
}