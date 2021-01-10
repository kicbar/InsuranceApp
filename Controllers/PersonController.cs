using AutoMapper;
using InsuranceApp.Data;
using InsuranceApp.Entities;
using InsuranceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceApp.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InsuranceApp.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<PersonDto>> Get()
        {
            var persons = _personRepository.GetPersons();

            if (persons == null)
                return NotFound();

            var personsDto = _mapper.Map<List<PersonDto>>(persons);

            return Ok(personsDto);
        }

        [HttpGet("{pesel}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PersonDto> Get(string pesel)
        {
            var person = _personRepository.GetPersonByPesel(pesel);

            if (person == null)
                return NotFound();

            var personDto = _mapper.Map<PersonDto>(person);

            return Ok(personDto);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] PersonDto personModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var person = _mapper.Map<Person>(personModel);

            _personRepository.AddPerson(person);

            return Created("api/person/" + person.Pesel, null);
        }

        [HttpPut("{pesel}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(string pesel, [FromBody] PersonDto personModel)
        {
            var person = _personRepository.GetPersonByPesel(pesel);

            if (person == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _personRepository.EditPerson(person, personModel);

            return NoContent();
        }

        [HttpDelete("{pesel}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(string pesel)
        {
            var person = _personRepository.GetPersonByPesel(pesel);

            if (person == null)
                return NotFound();

            _personRepository.DeletePerson(person);

            return NoContent();
        }

    }
}
