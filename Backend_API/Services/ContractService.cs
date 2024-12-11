using Backend_API.Data;
using Backend_API.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Backend_API.Services
{
    public class ContractService
    {
        private readonly DesignOfficeDbContext _context;

        public ContractService(DesignOfficeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contract> GetAll()
        {
            return _context.Contracts.ToList();
        }

        public Contract GetById(int id)
        {
            return _context.Contracts.Find(id);
        }

        public void Create(Contract contract)
        {
            _context.Contracts.Add(contract);
            _context.SaveChanges();
        }

        public bool Update(Contract contract)
        {
            var existingContract = _context.Contracts.Find(contract.ContractID);
            if (existingContract == null)
                return false;

            existingContract.ProjectID = contract.ProjectID;
            existingContract.ContractDate = contract.ContractDate;
            existingContract.ContractValueNet = contract.ContractValueNet;
            existingContract.VATRate = contract.VATRate;
            existingContract.ContractValueGross = contract.ContractValueGross;
            existingContract.ClientSignatureDate = contract.ClientSignatureDate;
            existingContract.CompanySignatureDate = contract.CompanySignatureDate;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var contract = _context.Contracts.Find(id);
            if (contract == null)
                return false;

            _context.Contracts.Remove(contract);
            _context.SaveChanges();
            return true;
        }
    }
}