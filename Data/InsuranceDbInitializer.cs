using InsuranceApp.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceApp.Data
{
    public class InsuranceDbInitializer
    {
        private readonly InsuranceDbContext _insuranceDbContext;
        private readonly ILogger<InsuranceDbInitializer> _logger;

        public InsuranceDbInitializer(InsuranceDbContext insuranceDbContext, ILogger<InsuranceDbInitializer> logger)
        {
            _insuranceDbContext = insuranceDbContext;
            _logger = logger;
        }

        public void Initialize()
        {
            if (_insuranceDbContext.Database.CanConnect())
            {
                _logger.LogInformation($"[DbInitializer] - Connection to database sucesfully at {DateTime.Now}.");
                if (!_insuranceDbContext.Contracts.Any())
                {
                    InsertSampleContractData();
                    _logger.LogInformation($"[DbInitializer] - Database [Contracts] Initialized at {DateTime.Now}.");
                }
                if (!_insuranceDbContext.Persons.Any())
                {
                    InsertSamplePersonData();
                    _logger.LogInformation($"[DbInitializer] - Database [Persons] Initialized at {DateTime.Now}.");
                }
            }
            else
                _logger.LogInformation($"[DbInitializer] - Critical Error during connect to database at  {DateTime.Now}.");
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

            _insuranceDbContext.Persons.AddRange(persons);
            _insuranceDbContext.SaveChanges();
        }

    }
}
