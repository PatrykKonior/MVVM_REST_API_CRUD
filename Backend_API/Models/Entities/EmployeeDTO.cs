namespace Backend_API.Models.Entities;

public class EmployeeDTO
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime? HireDate { get; set; }
    public decimal? Salary { get; set; }
    public string ProjectName { get; set; } // Dodane pole na nazwę projektu
}