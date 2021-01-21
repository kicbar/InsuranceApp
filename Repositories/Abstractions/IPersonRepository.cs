using InsuranceApp.Entities;
using InsuranceApp.Models;
using System.Collections.Generic;

namespace InsuranceApp.Repositories.Abstractions
{
    public interface IPersonRepository
    {
        public IEnumerable<PersonDto> GetPersonsEnum();
        public List<Person> GetPersons();
        public Person GetPersonByPesel(string pesel);
        public Person GetPersonById(int Id);
        public void AddPerson(Person person);
        public void EditPerson(Person person, PersonDto personModel);
        public void EditPersonByPesel(Person person, PersonDto personModel);
        public void DeletePerson(Person person);
    }
}
