using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class DepartmentService
    {
        private readonly DesignOfficeDbContext _context;

        public DepartmentService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }

        public void Create(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public bool Update(Department department)
        {
            var existingDepartment = _context.Departments.Find(department.DepartmentID);
            if (existingDepartment == null)
                return false;

            existingDepartment.DepartmentName = department.DepartmentName;
            existingDepartment.ManagerID = department.ManagerID;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
                return false;

            _context.Departments.Remove(department);
            _context.SaveChanges();
            return true;
        }
    }
}