namespace Backend_API.Models.Entities
{
    public class TimeLog
    {
        public int TimeLogID { get; set; }
        public int? EmployeeID { get; set; }
        public int? ProjectID { get; set; }
        public DateTime? LogDate { get; set; }
        public decimal? HoursWorked { get; set; }
        public decimal? HourlyRate { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}