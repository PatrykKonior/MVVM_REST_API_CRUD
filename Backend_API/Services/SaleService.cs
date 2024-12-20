using Backend_API.Data;
using Backend_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_API.Services;

public class SalesService
{
    private readonly DesignOfficeDbContext _context;

    public SalesService(DesignOfficeDbContext context)
    {
        _context = context;
    }

    public IEnumerable<SaleDTO> GetAll()
    {
        return _context.Sales
            .Include(s => s.Client)
            .Select(s => new SaleDTO
            {
                SaleID = s.SaleID,
                SaleDate = s.SaleDate,
                TotalNetAmount = s.TotalNetAmount,
                TotalVATAmount = s.TotalVATAmount,
                TotalGrossAmount = s.TotalGrossAmount,
                SaleStatus = s.SaleStatus ?? "Unknown",
                ClientName = s.Client != null ? s.Client.CompanyName ?? "N/A" : "N/A",
                ClientNIP = s.Client != null ? s.Client.NIP ?? "N/A" : "N/A",
                ClientRegon = s.Client != null ? s.Client.Regon ?? "N/A" : "N/A"
            })
            .ToList();
    }

    public SaleDTO GetById(int id)
    {
        return _context.Sales
            .Include(s => s.Client)
            .Where(s => s.SaleID == id)
            .Select(s => new SaleDTO
            {
                SaleID = s.SaleID,
                SaleDate = s.SaleDate,
                TotalNetAmount = s.TotalNetAmount,
                TotalVATAmount = s.TotalVATAmount,
                TotalGrossAmount = s.TotalGrossAmount,
                SaleStatus = s.SaleStatus ?? "Unknown",
                ClientName = s.Client != null ? s.Client.CompanyName ?? "N/A" : "N/A",
                ClientNIP = s.Client != null ? s.Client.NIP ?? "N/A" : "N/A",
                ClientRegon = s.Client != null ? s.Client.Regon ?? "N/A" : "N/A"
            })
            .FirstOrDefault();
    }

    public void Create(Sale sale)
    {
        _context.Sales.Add(sale);
        _context.SaveChanges();
    }

    public bool Update(Sale sale)
    {
        var existingSale = _context.Sales.FirstOrDefault(s => s.SaleID == sale.SaleID);
        if (existingSale == null) return false;

        existingSale.SaleDate = sale.SaleDate;
        existingSale.TotalNetAmount = sale.TotalNetAmount;
        existingSale.TotalVATAmount = sale.TotalVATAmount;
        existingSale.TotalGrossAmount = sale.TotalGrossAmount;
        existingSale.SaleStatus = sale.SaleStatus;
        existingSale.ClientID = sale.ClientID;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var sale = _context.Sales.Find(id);
        if (sale == null) return false;

        _context.Sales.Remove(sale);
        _context.SaveChanges();
        return true;
    }
}
