namespace Backend_API.Models.Entities
{
    public class Project
    {
        public int ProjectID { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; } // Właściwość nawigacyjna do Client

        public int ManagerID { get; set; }
        public Employee Manager { get; set; } // Właściwość nawigacyjna do Manager (Employee)

        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public decimal? ProjectBudget { get; set; }
        public decimal? VATRate { get; set; }
        public string ProjectStatus { get; set; }
    }
}