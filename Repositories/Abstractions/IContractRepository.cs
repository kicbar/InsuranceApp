using InsuranceApp.Entities;
using InsuranceApp.Models;
using System.Collections.Generic;

namespace InsuranceApp.Repositories.Abstractions
{ 
    public interface IContractRepository
    {
        public List<Contract> GetContracts();
        public Contract GetContractById(string contractId);
        public void AddContract(Contract contract);
        public void EditContract(Contract contract, ContractDto contractDto);
        public void DeleteContract(Contract contract);
    }
}
