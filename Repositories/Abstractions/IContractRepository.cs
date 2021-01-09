using InsuranceApp.Entities;
using System.Collections.Generic;

namespace InsuranceApp.Repositories.Abstractions
{ 
    public interface IContractRepository
    {
        public List<Contract> GetContracts();
        public Contract GetContractById(string contractId);
        public void AddContract();
        public void EditContract();
        public void DeleteContract();
    }
}
