using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class MaterialService
    {
        private readonly DesignOfficeDbContext _context;

        public MaterialService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Material> GetAll()
        {
            return _context.Materials.ToList();
        }

        public Material GetById(int id)
        {
            return _context.Materials.Find(id);
        }

        public void Create(Material material)
        {
            _context.Materials.Add(material);
            _context.SaveChanges();
        }

        public bool Update(Material material)
        {
            var existingMaterial = _context.Materials.Find(material.MaterialID);
            if (existingMaterial == null)
                return false;

            existingMaterial.MaterialName = material.MaterialName;
            existingMaterial.MaterialDescription = material.MaterialDescription;
            existingMaterial.UnitPrice = material.UnitPrice;
            existingMaterial.VATRate = material.VATRate;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var material = _context.Materials.Find(id);
            if (material == null)
                return false;

            _context.Materials.Remove(material);
            _context.SaveChanges();
            return true;
        }
    }
}