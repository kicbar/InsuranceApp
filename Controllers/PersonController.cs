using AutoMapper;
using InsuranceApp.Data;
using InsuranceApp.Entities;
using InsuranceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly InsuranceDbContext _insuranceDbContext;
        private readonly IMapper _mapper;

        public PersonController(InsuranceDbContext insuranceDbContext, IMapper mapper)
        {
            _insuranceDbContext = insuranceDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> Get()
        {
            var persons = _insuranceDbContext.Persons.ToList();

            if (persons == null)
                return NotFound();

            var personsDto = _mapper.Map<List<PersonDto>>(persons);

            return Ok(personsDto);
        }

        [HttpGet("{pesel}")]
        public ActionResult<PersonDto> Get(string pesel)
        {
            var person = _insuranceDbContext.Persons.FirstOrDefault(p => p.Pesel == pesel);

            if (person == null)
                return NotFound();

            var personDto = _mapper.Map<PersonDto>(person);

            return Ok(personDto);
        }

        [HttpPost]
        public ActionResult Post([FromBody] PersonDto personModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var person = _mapper.Map<Person>(personModel);

            _insuranceDbContext.Persons.Add(person);
            _insuranceDbContext.SaveChanges();

            return Created("api/person/" + person.Pesel, null);
        }

        [HttpPut("{pesel}")]
        public ActionResult Put(string pesel, [FromBody] PersonDto personModel)
        {
            var person = _insuranceDbContext.Persons.FirstOrDefault(p => p.Pesel == pesel);

            if (person == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            person.FirstName = personModel.FirstName;
            person.LastName = personModel.LastName;
            person.Pesel = personModel.Pesel;
            person.Nationality = personModel.Nationality;

            _insuranceDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{pesel}")]
        public ActionResult Delete(string pesel)
        {
            var person = _insuranceDbContext.Persons.FirstOrDefault(p => p.Pesel == pesel);

            if (person == null)
                return NotFound();

            _insuranceDbContext.Persons.Remove(person);
            _insuranceDbContext.SaveChanges();

            return NoContent();
        }

    }
}
