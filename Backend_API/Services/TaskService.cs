using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class TasksService
    {
        private readonly DesignOfficeDbContext _context;

        public TasksService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tasks> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public Tasks GetById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void Create(Tasks tasks)
        {
            _context.Tasks.Add(tasks);
            _context.SaveChanges();
        }

        public bool Update(Tasks tasks)
        {
            var existingTasks = _context.Tasks.Find(tasks.TaskID);
            if (existingTasks == null)
                return false;

            existingTasks.ProjectID = tasks.ProjectID;
            existingTasks.TaskName = tasks.TaskName;
            existingTasks.TaskDescription = tasks.TaskDescription;
            existingTasks.AssignedEmployeeID = tasks.AssignedEmployeeID;
            existingTasks.TaskStartDate = tasks.TaskStartDate;
            existingTasks.TaskEndDate = tasks.TaskEndDate;
            existingTasks.EstimatedHours = tasks.EstimatedHours;
            existingTasks.TaskStatus = tasks.TaskStatus;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var tasks = _context.Tasks.Find(id);
            if (tasks == null)
                return false;

            _context.Tasks.Remove(tasks);
            _context.SaveChanges();
            return true;
        }
    }
}