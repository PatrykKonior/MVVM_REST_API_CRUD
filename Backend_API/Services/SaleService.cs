using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class SalesService
    {
        private readonly DesignOfficeDbContext _context;

        public SalesService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sale> GetAll()
        {
            return _context.Sales.ToList();
        }

        public Sale GetById(int id)
        {
            return _context.Sales.Find(id);
        }

        public void Create(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public bool Update(Sale sale)
        {
            var existingSale = _context.Sales.Find(sale.SaleID);
            if (existingSale == null)
                return false;

            existingSale.ClientID = sale.ClientID;
            existingSale.SaleDate = sale.SaleDate;
            existingSale.TotalNetAmount = sale.TotalNetAmount;
            existingSale.TotalVATAmount = sale.TotalVATAmount;
            existingSale.TotalGrossAmount = sale.TotalGrossAmount;
            existingSale.SaleStatus = sale.SaleStatus;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var sale = _context.Sales.Find(id);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            _context.SaveChanges();
            return true;
        }
    }
}