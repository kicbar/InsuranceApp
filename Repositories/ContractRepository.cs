using InsuranceApp.Data;
using InsuranceApp.Entities;
using InsuranceApp.Models;
using InsuranceApp.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
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
            contract.InsuranceType = contractDto.InsuranceType;
            contract.StartDate = contractDto.StartDate;

            _insuranceDbContext.SaveChanges();
        }

        public void DeleteContract(Contract contract)
        {
            _insuranceDbContext.Contracts.Remove(contract);
            _insuranceDbContext.SaveChanges();
        }

        public List<Contract> GetContractsRegister()
        {
            return _insuranceDbContext.Contracts.Include(p => p.Person).ToList();
        }

        public Contract GetContractRegisterById(string contractId)
        {
            return _insuranceDbContext.Contracts.Include(p => p.Person).FirstOrDefault(c => c.ContractNr == contractId);
        }

        public void AddContractRegister(Contract contract)
        {
            contract.EndDate = contract.StartDate.AddYears(1);
            _insuranceDbContext.Contracts.Add(contract);
            _insuranceDbContext.SaveChanges();
        }

        public void EditContractRegister(Contract contract, ContractRegisterDto contractRegisterDto)
        {
            contract.ContractNr = contractRegisterDto.ContractNr;
            contract.StartDate = contractRegisterDto.StartDate;
            contract.EndDate = contract.StartDate.AddYears(1);
            contract.InsuranceType = contractRegisterDto.InsuranceType;
            contract.Value = contractRegisterDto.Value;
            contract.Person.FirstName = contractRegisterDto.FirstName;
            contract.Person.LastName = contractRegisterDto.LastName;
            contract.Person.Pesel = contractRegisterDto.Pesel;

            _insuranceDbContext.SaveChanges();
        }

        public void DeleteContractRegister(Contract contract)
        {
            _insuranceDbContext.Contracts.Remove(contract);
            _insuranceDbContext.SaveChanges();
        }
    }
}
