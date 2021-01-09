using InsuranceApp.Data;
using InsuranceApp.Entities;
using InsuranceApp.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private InsuranceDbContext _insuranceDbContext;


        public PersonRepository(InsuranceDbContext insuranceDbContext)
        {
            _insuranceDbContext = insuranceDbContext;
        }

        List<Person> IPersonRepository.GetPersons()
        {
            var persons = _insuranceDbContext.Persons.ToList();
            return persons;
        }

        public void AddPerson()
        {
            throw new NotImplementedException();
        }

        public void DeletePerson()
        {
            throw new NotImplementedException();
        }

        public void EditPerson()
        {
            throw new NotImplementedException();
        }

        public Person GetPersonByPesel(string pesel)
        {
            throw new NotImplementedException();
        }

    }
}
