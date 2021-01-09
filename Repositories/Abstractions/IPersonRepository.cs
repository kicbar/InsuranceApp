using InsuranceApp.Entities;
using System.Collections.Generic;

namespace InsuranceApp.Repositories.Abstractions
{
    public interface IPersonRepository
    {
        public List<Person> GetPersons();
        public Person GetPersonByPesel(string pesel);
        public void AddPerson();
        public void EditPerson();
        public void DeletePerson();
    }
}
