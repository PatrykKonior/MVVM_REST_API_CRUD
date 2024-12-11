namespace Backend_API.Models.Entities
{
    public class Project
    {
        public int ProjectID { get; set; }
        public int? ClientID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public decimal? ProjectBudget { get; set; }
        public decimal? VATRate { get; set; }
        public string ProjectStatus { get; set; }
    }
}