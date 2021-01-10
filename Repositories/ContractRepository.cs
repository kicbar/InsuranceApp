using InsuranceApp.Data;
using InsuranceApp.Entities;
using InsuranceApp.Models;
using InsuranceApp.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceApp.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private InsuranceDbContext _insuranceDbContext;

        public ContractRepository(InsuranceDbContext insuranceDbContext)
        {
            _insuranceDbContext = insuranceDbContext;
        }

        public List<Contract> GetContracts()
        {
            return _insuranceDbContext.Contracts.ToList();
        }

        public Contract GetContractById(string contractId)
        {
            return _insuranceDbContext.Contracts.FirstOrDefault(c => c.ContractNr == contractId);
        }

        public void AddContract(Contract contract)
        {
            _insuranceDbContext.Contracts.Add(contract);
            _insuranceDbContext.SaveChanges();
        }

        public void EditContract(Contract contract, ContractDto contractDto)
        {
            contract.ContractNr = contractDto.ContractNr;
            //contract.InsuredPerson = contractDto.InsuredPerson;
            contract.InsuranceType = contractDto.InsuranceType;
            contract.StartDate = contractDto.StartDate;

            _insuranceDbContext.SaveChanges();
        }

        public void DeleteContract(Contract contract)
        {
            _insuranceDbContext.Contracts.Remove(contract);
            _insuranceDbContext.SaveChanges();
        }

    }
}
