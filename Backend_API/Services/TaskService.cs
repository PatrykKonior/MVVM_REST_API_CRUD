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
            return _context.Taskss.ToList();
        }

        public Tasks GetById(int id)
        {
            return _context.Taskss.Find(id);
        }

        public void Create(Tasks tasks)
        {
            _context.Taskss.Add(tasks);
            _context.SaveChanges();
        }

        public bool Update(Tasks tasks)
        {
            var existingTasks = _context.Taskss.Find(tasks.TasksID);
            if (existingTasks == null)
                return false;

            existingTasks.ProjectID = tasks.ProjectID;
            existingTasks.TasksName = tasks.TasksName;
            existingTasks.TasksDescription = tasks.TasksDescription;
            existingTasks.AssignedEmployeeID = tasks.AssignedEmployeeID;
            existingTasks.TasksStartDate = tasks.TasksStartDate;
            existingTasks.TasksEndDate = tasks.TasksEndDate;
            existingTasks.EstimatedHours = tasks.EstimatedHours;
            existingTasks.TasksStatus = tasks.TasksStatus;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var tasks = _context.Taskss.Find(id);
            if (tasks == null)
                return false;

            _context.Taskss.Remove(tasks);
            _context.SaveChanges();
            return true;
        }
    }
}