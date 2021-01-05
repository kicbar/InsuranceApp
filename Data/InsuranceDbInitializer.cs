using InsuranceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceApp.Data
{
    public class InsuranceDbInitializer
    {
        private readonly InsuranceDbContext _insuranceDbContext;

        public InsuranceDbInitializer(InsuranceDbContext insuranceDbContext)
        {
            _insuranceDbContext = insuranceDbContext;
        }

        public void Initialize()
        {
            if (_insuranceDbContext.Database.CanConnect())
            {
                if (!_insuranceDbContext.Contracts.Any())
                    InsertSampleContractData();
            }
        }

        public void InsertSampleContractData()
        {
            var contracts = new List<Contract>
            {
                new Contract
                {
                    ContractNr = "L1231",
                    InsuredPerson = "Harvey Specter",
                    InsuranceType = "Life",
                    StartDate = DateTime.Parse("2020-12-31")
                },
                new Contract
                {
                    ContractNr = "M0101",
                    InsuredPerson = "Gregory House",
                    InsuranceType = "Motor",
                    StartDate = DateTime.Parse("2020-01-01T00:00:00")
                },
                new Contract
                {
                    ContractNr = "T0101",
                    InsuredPerson = "DonnaPaulsen",
                    InsuranceType = "Travel",
                    StartDate = DateTime.Parse("2020-01-01T00:00:00")
                },
                new Contract
                {
                    ContractNr = "L1212",
                    InsuredPerson = "Thomas Nowak",
                    InsuranceType = "Life",
                    StartDate = DateTime.Parse("2020/12/12")
                }
            };

            _insuranceDbContext.Contracts.AddRange(contracts);
            _insuranceDbContext.SaveChanges();
        }

    }
}
