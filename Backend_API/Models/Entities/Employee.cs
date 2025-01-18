namespace Backend_API.Models.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? HireDate { get; set; }
        public decimal? Salary { get; set; }
        
        // Dodano właściwość nawigacyjną
        public ICollection<Project>? Projects { get; set; }
    }
}