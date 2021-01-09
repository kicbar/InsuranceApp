using InsuranceApp.Entities;
using InsuranceApp.Models;
using System.Collections.Generic;

namespace InsuranceApp.Repositories.Abstractions
{
    public interface IPersonRepository
    {
        public List<Person> GetPersons();
        public Person GetPersonByPesel(string pesel);
        public void AddPerson(Person person);
        public void EditPerson(Person person, PersonDto personModel);
        public void DeletePerson(Person person);
    }
}
