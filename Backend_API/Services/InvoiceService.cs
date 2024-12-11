using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class InvoiceService
    {
        private readonly DesignOfficeDbContext _context;

        public InvoiceService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _context.Invoices.ToList();
        }

        public Invoice GetById(int id)
        {
            return _context.Invoices.Find(id);
        }

        public void Create(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        public bool Update(Invoice invoice)
        {
            var existingInvoice = _context.Invoices.Find(invoice.InvoiceID);
            if (existingInvoice == null)
                return false;

            existingInvoice.SaleID = invoice.SaleID;
            existingInvoice.InvoiceDate = invoice.InvoiceDate;
            existingInvoice.PaymentDueDate = invoice.PaymentDueDate;
            existingInvoice.InvoiceStatus = invoice.InvoiceStatus;
            existingInvoice.TotalAmount = invoice.TotalAmount;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice == null)
                return false;

            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
            return true;
        }
    }
}