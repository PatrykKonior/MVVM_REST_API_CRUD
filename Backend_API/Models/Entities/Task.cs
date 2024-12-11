namespace Backend_API.Models.Entities
{
    public class Tasks
    {
        public int TasksID { get; set; }
        public int? ProjectID { get; set; }
        public string TasksName { get; set; }
        public string TasksDescription { get; set; }
        public int? AssignedEmployeeID { get; set; }
        public DateTime? TasksStartDate { get; set; }
        public DateTime? TasksEndDate { get; set; }
        public decimal? EstimatedHours { get; set; }
        public string TasksStatus { get; set; }
    }
}