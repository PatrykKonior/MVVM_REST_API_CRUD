using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class ExpenseService
    {
        private readonly DesignOfficeDbContext _context;

        public ExpenseService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Expense> GetAll()
        {
            return _context.Expenses.ToList();
        }

        public Expense GetById(int id)
        {
            return _context.Expenses.Find(id);
        }

        public void Create(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public bool Update(Expense expense)
        {
            var existingExpense = _context.Expenses.Find(expense.ExpenseID);
            if (existingExpense == null)
                return false;

            existingExpense.ProjectID = expense.ProjectID;
            existingExpense.ExpenseDate = expense.ExpenseDate;
            existingExpense.ExpenseDescription = expense.ExpenseDescription;
            existingExpense.NetAmount = expense.NetAmount;
            existingExpense.VATAmount = expense.VATAmount;
            existingExpense.GrossAmount = expense.GrossAmount;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense == null)
                return false;

            _context.Expenses.Remove(expense);
            _context.SaveChanges();
            return true;
        }
    }
}