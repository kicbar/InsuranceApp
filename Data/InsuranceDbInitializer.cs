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
                if (!_insuranceDbContext.Perosns.Any())
                    InsertSamplePersonData();
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
                    InsuredPerson = "Donna Paulsen",
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

        public void InsertSamplePersonData()
        { 
            var persons = new List<Person>
            { 
                new Person
                { 
                    FirstName = "Harvey",
                    LastName = "Specter",
                    Pesel = "73112156714",
                    Nationality = "American",
                    InsertDate = DateTime.Now
                },
                new Person
                {
                    FirstName = "Gregory",
                    LastName = "House",
                    Pesel = "57011899990",
                    Nationality = "American",
                    InsertDate = DateTime.Now
                },
                new Person
                {
                    FirstName = "Donna",
                    LastName = "Paulsen",
                    Pesel = "89121204861",
                    Nationality = "American",
                    InsertDate = DateTime.Now
                },
                new Person
                {
                    FirstName = "Thomas",
                    LastName = "Nowak",
                    Pesel = "95031262019",
                    Nationality = "Polish",
                    InsertDate = DateTime.Now
                }
            };

            _insuranceDbContext.Perosns.AddRange(persons);
            _insuranceDbContext.SaveChanges();
        }

    }
}
