﻿using AutoMapper;
using InsuranceApp.Data;
using InsuranceApp.Entities;
using InsuranceApp.Models;
using InsuranceApp.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private InsuranceDbContext _insuranceDbContext;
        private IMapper _mapper;

        public PersonController(IPersonRepository personRepository, InsuranceDbContext insuranceDbContext, IMapper mapper)
        {
            _personRepository = personRepository;
            _insuranceDbContext = insuranceDbContext;
            _mapper = mapper;
        }

        // GET: Persons
        public async Task<IActionResult> Index()
        {
            var persons = _personRepository.GetPersons();

            if (persons == null)
                return NotFound();

            var personsDto = _mapper.Map<List<PersonDto>>(persons);

            return View(personsDto);
        }

        // GET: Person/Details/{pesel}
        public async Task<IActionResult> Details(string? pesel)
        {
            if (pesel == null)
            {
                return NotFound();
            }

            var person = _personRepository.GetPersonByPesel(pesel);

            if (person == null)
            {
                return NotFound();
            }

            var personDto = _mapper.Map<PersonDto>(person);

            return View(personDto);
        }

        // GET: Movies/Edit/{pesel}
        public async Task<IActionResult> Edit(string? pesel)
        {
            if (pesel == null)
            {
                return NotFound();
            }

            var person = _personRepository.GetPersonByPesel(pesel);

            if (person == null)
            {
                return NotFound();
            }

            var personDto = _mapper.Map<PersonDto>(person);

            return View(personDto);
        }

        // POST: Person/Edit/{pesel}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string pesel, PersonDto personDto)
        {
            if (pesel != personDto.Pesel)
            {
                return NotFound();
            }

            var person = _personRepository.GetPersonByPesel(pesel);

            if (ModelState.IsValid)
            {
                try
                {
                    _personRepository.EditPerson(person, personDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personDto);
        }

    }
}
