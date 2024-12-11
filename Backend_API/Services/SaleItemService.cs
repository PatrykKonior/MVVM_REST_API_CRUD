using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class SaleItemsService
    {
        private readonly DesignOfficeDbContext _context;

        public SaleItemsService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SaleItem> GetAll()
        {
            return _context.SaleItems.ToList();
        }

        public SaleItem GetById(int id)
        {
            return _context.SaleItems.Find(id);
        }

        public void Create(SaleItem saleItem)
        {
            _context.SaleItems.Add(saleItem);
            _context.SaveChanges();
        }

        public bool Update(SaleItem saleItem)
        {
            var existingItem = _context.SaleItems.Find(saleItem.SaleItemID);
            if (existingItem == null)
                return false;

            existingItem.Description = saleItem.Description;
            existingItem.Quantity = saleItem.Quantity;
            existingItem.UnitPriceNet = saleItem.UnitPriceNet;
            existingItem.NetAmount = saleItem.NetAmount;
            existingItem.VATRate = saleItem.VATRate;
            existingItem.VATAmount = saleItem.VATAmount;
            existingItem.GrossAmount = saleItem.GrossAmount;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var saleItem = _context.SaleItems.Find(id);
            if (saleItem == null)
                return false;

            _context.SaleItems.Remove(saleItem);
            _context.SaveChanges();
            return true;
        }
    }
}