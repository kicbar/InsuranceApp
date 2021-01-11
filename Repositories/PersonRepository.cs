using AutoMapper;
using InsuranceApp.Data;
using InsuranceApp.Entities;
using InsuranceApp.Models;
using InsuranceApp.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private InsuranceDbContext _insuranceDbContext;
        private IMapper _mapper;

        public PersonRepository(InsuranceDbContext insuranceDbContext, IMapper mapper)
        {
            _insuranceDbContext = insuranceDbContext;
            _mapper = mapper;
        }

        public IEnumerable<PersonDto> GetPersonsEnum()
        {
            var persons = _insuranceDbContext.Persons;
            var personsDto = _mapper.Map<IEnumerable<PersonDto>>(persons);
            return personsDto;
        }

        List<Person> IPersonRepository.GetPersons()
        {
            return _insuranceDbContext.Persons.ToList();
        }

        public Person GetPersonByPesel(string pesel)
        {
            return _insuranceDbContext.Persons.FirstOrDefault(p => p.Pesel == pesel);
        }

        public void AddPerson(Person person)
        {
            _insuranceDbContext.Persons.Add(person);
            _insuranceDbContext.SaveChanges();
        }

        public void EditPerson(Person person, PersonDto personModel)
        {
            person.FirstName = personModel.FirstName;
            person.LastName = personModel.LastName;
            person.Pesel = personModel.Pesel;
            person.Nationality = personModel.Nationality;

            _insuranceDbContext.SaveChanges();
        }
        public void DeletePerson(Person person)
        {
            _insuranceDbContext.Persons.Remove(person);
            _insuranceDbContext.SaveChanges();
        }

    }
}
