using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class TimeLogsService
    {
        private readonly DesignOfficeDbContext _context;

        public TimeLogsService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TimeLog> GetAll()
        {
            return _context.TimeLogs.ToList();
        }

        public TimeLog GetById(int id)
        {
            return _context.TimeLogs.Find(id);
        }

        public void Create(TimeLog timeLog)
        {
            _context.TimeLogs.Add(timeLog);
            _context.SaveChanges();
        }

        public bool Update(TimeLog timeLog)
        {
            var existingLog = _context.TimeLogs.Find(timeLog.TimeLogID);
            if (existingLog == null)
                return false;

            existingLog.EmployeeID = timeLog.EmployeeID;
            existingLog.ProjectID = timeLog.ProjectID;
            existingLog.LogDate = timeLog.LogDate;
            existingLog.HoursWorked = timeLog.HoursWorked;
            existingLog.HourlyRate = timeLog.HourlyRate;
            existingLog.TotalAmount = timeLog.TotalAmount;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var timeLog = _context.TimeLogs.Find(id);
            if (timeLog == null)
                return false;

            _context.TimeLogs.Remove(timeLog);
            _context.SaveChanges();
            return true;
        }
    }
}