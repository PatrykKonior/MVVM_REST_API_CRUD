using Microsoft.EntityFrameworkCore;
using Backend_API.Models.Entities;

namespace Backend_API.Data
{
    public class DesignOfficeDbContext : DbContext
    {
        public DesignOfficeDbContext(DbContextOptions<DesignOfficeDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientDetail> ClientDetails { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tasks> Taskss { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ProjectMaterial> ProjectMaterials { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
    }
}