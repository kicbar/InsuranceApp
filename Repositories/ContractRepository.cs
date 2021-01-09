using InsuranceApp.Data;
using InsuranceApp.Entities;
using InsuranceApp.Repositories.Abstractions;
using System;
using System.Collections.Generic;

namespace InsuranceApp.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private InsuranceDbContext _insuranceDbContext;

        public ContractRepository(InsuranceDbContext insuranceDbContext)
        {
            _insuranceDbContext = insuranceDbContext;
        }

        public void AddContract()
        {
            throw new NotImplementedException();
        }

        public void DeleteContract()
        {
            throw new NotImplementedException();
        }

        public void EditContract()
        {
            throw new NotImplementedException();
        }

        Contract IContractRepository.GetContractById(string contractId)
        {
            throw new NotImplementedException();
        }

        List<Contract> IContractRepository.GetContracts()
        {
            throw new NotImplementedException();
        }
    }
}
