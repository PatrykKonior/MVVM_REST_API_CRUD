namespace Backend_API.Models.Entities
{
    public class ProjectAssignment
    {
        public int ProjectAssignmentID { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public string Role { get; set; }
    }
}
