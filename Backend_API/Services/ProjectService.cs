using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Backend_API.Services
{
    public class ProjectService
    {
        private readonly DesignOfficeDbContext _context;

        public ProjectService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            return _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Manager)
                .Select(p => new ProjectDTO
                {
                    ProjectID = p.ProjectID,
                    ProjectName = p.ProjectName,
                    ProjectType = p.ProjectType,
                    ProjectStartDate = p.ProjectStartDate,
                    ProjectEndDate = p.ProjectEndDate,
                    ProjectBudget = p.ProjectBudget,
                    VATRate = p.VATRate,
                    ProjectStatus = p.ProjectStatus,
                    ClientName = p.Client != null ? p.Client.CompanyName : null,
                    ClientNIP = p.Client != null ? p.Client.NIP : null,
                    ManagerFirstName = p.Manager != null ? p.Manager.FirstName : null,
                    ManagerLastName = p.Manager != null ? p.Manager.LastName : null,
                    ManagerPosition = p.Manager != null ? p.Manager.Position : null
                })
                .ToList();
        }

        public ProjectDTO GetById(int id)
        {
            return _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Manager)
                .Where(p => p.ProjectID == id)
                .Select(p => new ProjectDTO
                {
                    ProjectID = p.ProjectID,
                    ProjectName = p.ProjectName,
                    ProjectType = p.ProjectType,
                    ProjectStartDate = p.ProjectStartDate,
                    ProjectEndDate = p.ProjectEndDate,
                    ProjectBudget = p.ProjectBudget,
                    VATRate = p.VATRate,
                    ProjectStatus = p.ProjectStatus,
                    ClientName = p.Client != null ? p.Client.CompanyName : null,
                    ClientNIP = p.Client != null ? p.Client.NIP : null,
                    ManagerFirstName = p.Manager != null ? p.Manager.FirstName : null,
                    ManagerLastName = p.Manager != null ? p.Manager.LastName : null,
                    ManagerPosition = p.Manager != null ? p.Manager.Position : null
                })
                .FirstOrDefault();
        }
        
        public IEnumerable<EmployeeDTO> GetEmployeesForProject(int projectId)
        {
            var employees = _context.ProjectAssignments
                .Where(pa => pa.ProjectID == projectId)
                .Select(pa => new EmployeeDTO
                {
                    EmployeeID = pa.Employee.EmployeeID,
                    FirstName = pa.Employee.FirstName,
                    LastName = pa.Employee.LastName,
                    Position = pa.Employee.Position,
                    PhoneNumber = pa.Employee.PhoneNumber,
                    Email = pa.Employee.Email,
                    HireDate = pa.Employee.HireDate,
                    Salary = pa.Employee.Salary,
                    ProjectName = pa.Project.ProjectName // Pobierz nazwę projektu
                })
                .ToList();

            return employees;
        }

        public Client GetClientById(int clientId)
        {
            return _context.Clients.FirstOrDefault(c => c.ClientID == clientId);
        }

        public Employee GetManagerById(int managerId)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeID == managerId);
        }

        public void Create(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public bool Update(Project project)
        {
            var existingProject = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Manager)
                .FirstOrDefault(p => p.ProjectID == project.ProjectID);

            if (existingProject == null)
                return false;

            existingProject.ProjectName = project.ProjectName;
            existingProject.ProjectType = project.ProjectType;
            existingProject.ProjectStartDate = project.ProjectStartDate;
            existingProject.ProjectEndDate = project.ProjectEndDate;
            existingProject.ProjectBudget = project.ProjectBudget;
            existingProject.VATRate = project.VATRate;
            existingProject.ProjectStatus = project.ProjectStatus;
            existingProject.ClientID = project.ClientID;
            existingProject.Client = project.Client;
            existingProject.ManagerID = project.ManagerID;
            existingProject.Manager = project.Manager;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null)
                return false;

            _context.Projects.Remove(project);
            _context.SaveChanges();
            return true;
        }
    }
}
