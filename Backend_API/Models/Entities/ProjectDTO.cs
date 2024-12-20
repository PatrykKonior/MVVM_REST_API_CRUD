namespace Backend_API.Models.Entities;

public class ProjectDTO
{
    public int ProjectID { get; set; }
    public string ProjectName { get; set; }
    public string ProjectType { get; set; }
    public DateTime? ProjectStartDate { get; set; }
    public DateTime? ProjectEndDate { get; set; }
    public decimal? ProjectBudget { get; set; }
    public decimal? VATRate { get; set; }
    public string ProjectStatus { get; set; }
    public string ClientName { get; set; } 
    public string ClientNIP { get; set; } 
    public string ManagerFirstName { get; set; }
    public string ManagerLastName { get; set; }
    public string ManagerPosition { get; set; }
}