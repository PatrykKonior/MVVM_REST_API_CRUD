using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class PaymentService
    {
        private readonly DesignOfficeDbContext _context;

        public PaymentService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments.ToList();
        }

        public Payment GetById(int id)
        {
            return _context.Payments.Find(id);
        }

        public void Create(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public bool Update(Payment payment)
        {
            var existingPayment = _context.Payments.Find(payment.PaymentID);
            if (existingPayment == null)
                return false;

            existingPayment.InvoiceID = payment.InvoiceID;
            existingPayment.PaymentDate = payment.PaymentDate;
            existingPayment.PaymentAmount = payment.PaymentAmount;
            existingPayment.PaymentMethod = payment.PaymentMethod;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment == null)
                return false;

            _context.Payments.Remove(payment);
            _context.SaveChanges();
            return true;
        }
    }
}