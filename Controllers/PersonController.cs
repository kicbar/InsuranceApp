using InsuranceApp.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            return View(_personRepository.GetPersonsEnum());
        }
    }
}
