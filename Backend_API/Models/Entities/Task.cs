using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models.Entities
{
    public class Tasks
    {
        [Key] // Definiuje klucz główny
        public int TaskID { get; set; }

        public int? ProjectID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int? AssignedEmployeeID { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public decimal? EstimatedHours { get; set; }
        public string TaskStatus { get; set; }
    }
}