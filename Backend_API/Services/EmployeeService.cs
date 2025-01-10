using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class EmployeeService
    {
        private readonly DesignOfficeDbContext _context;

        public EmployeeService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        
        public IEnumerable<ProjectDTO> GetProjectsForEmployee(int employeeId)
        {
            var projects = _context.ProjectAssignments
                .Where(pa => pa.EmployeeID == employeeId)
                .Select(pa => new ProjectDTO
                {
                    ProjectID = pa.Project.ProjectID,
                    ProjectName = pa.Project.ProjectName,
                    ProjectType = pa.Project.ProjectType,
                    ProjectStartDate = pa.Project.ProjectStartDate,
                    ProjectEndDate = pa.Project.ProjectEndDate,
                    ProjectBudget = pa.Project.ProjectBudget,
                    VATRate = pa.Project.VATRate,
                    ProjectStatus = pa.Project.ProjectStatus,
                    EmployeeName = pa.Employee.FirstName + " " + pa.Employee.LastName // Imię i nazwisko pracownika
                })
                .ToList();

            return projects;
        }

        public bool Update(Employee employee)
        {
            var existingEmployee = _context.Employees.Find(employee.EmployeeID);
            if (existingEmployee == null)
                return false;

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Position = employee.Position;
            existingEmployee.PhoneNumber = employee.PhoneNumber;
            existingEmployee.Email = employee.Email;
            existingEmployee.HireDate = employee.HireDate;
            existingEmployee.Salary = employee.Salary;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return true;
        }
    }
}