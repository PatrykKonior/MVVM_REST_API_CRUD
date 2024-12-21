using Backend_API.Data;
using Backend_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Backend_API.Services;

public class PaymentsService
{
    private readonly DesignOfficeDbContext _context;

    public PaymentsService(DesignOfficeDbContext context)
    {
        _context = context;
    }

    public IEnumerable<PaymentDTO> GetAll()
    {
        return _context.Payments
            .Include(p => p.Invoice)
            .Select(p => new PaymentDTO
            {
                PaymentID = p.PaymentID,
                PaymentDate = p.PaymentDate,
                PaymentAmount = p.PaymentAmount,
                PaymentMethod = p.PaymentMethod,
                InvoiceDate = p.Invoice == null ? (DateTime?)null : p.Invoice.InvoiceDate,
                InvoiceStatus = p.Invoice == null ? null : p.Invoice.InvoiceStatus,
                TotalAmount = p.Invoice == null ? (decimal?)null : p.Invoice.TotalAmount
            })
            .ToList();
    }

    public PaymentDTO? GetById(int id)
    {
        return _context.Payments
            .Include(p => p.Invoice)
            .Where(p => p.PaymentID == id)
            .Select(p => new PaymentDTO
            {
                PaymentID = p.PaymentID,
                PaymentDate = p.PaymentDate,
                PaymentAmount = p.PaymentAmount,
                PaymentMethod = p.PaymentMethod,
                InvoiceDate = p.Invoice == null ? (DateTime?)null : p.Invoice.InvoiceDate,
                InvoiceStatus = p.Invoice == null ? null : p.Invoice.InvoiceStatus,
                TotalAmount = p.Invoice == null ? (decimal?)null : p.Invoice.TotalAmount
            })
            .FirstOrDefault();
    }

    public void Create(Payment payment)
    {
        _context.Payments.Add(payment);
        _context.SaveChanges();
    }

    public bool Update(Payment payment)
    {
        var existingPayment = _context.Payments.FirstOrDefault(p => p.PaymentID == payment.PaymentID);
        if (existingPayment == null) return false;

        existingPayment.PaymentDate = payment.PaymentDate;
        existingPayment.PaymentAmount = payment.PaymentAmount;
        existingPayment.PaymentMethod = payment.PaymentMethod;
        existingPayment.InvoiceID = payment.InvoiceID;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var payment = _context.Payments.Find(id);
        if (payment == null) return false;

        _context.Payments.Remove(payment);
        _context.SaveChanges();
        return true;
    }
}