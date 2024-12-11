using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class ProjectMaterialService
    {
        private readonly DesignOfficeDbContext _context;

        public ProjectMaterialService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectMaterial> GetAll()
        {
            return _context.ProjectMaterials.ToList();
        }

        public ProjectMaterial GetById(int id)
        {
            return _context.ProjectMaterials.Find(id);
        }

        public void Create(ProjectMaterial projectMaterial)
        {
            _context.ProjectMaterials.Add(projectMaterial);
            _context.SaveChanges();
        }

        public bool Update(ProjectMaterial projectMaterial)
        {
            var existingProjectMaterial = _context.ProjectMaterials.Find(projectMaterial.ProjectMaterialID);
            if (existingProjectMaterial == null)
                return false;

            existingProjectMaterial.ProjectID = projectMaterial.ProjectID;
            existingProjectMaterial.MaterialID = projectMaterial.MaterialID;
            existingProjectMaterial.Quantity = projectMaterial.Quantity;
            existingProjectMaterial.UnitPrice = projectMaterial.UnitPrice;
            existingProjectMaterial.VATAmount = projectMaterial.VATAmount;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var projectMaterial = _context.ProjectMaterials.Find(id);
            if (projectMaterial == null)
                return false;

            _context.ProjectMaterials.Remove(projectMaterial);
            _context.SaveChanges();
            return true;
        }
    }
}