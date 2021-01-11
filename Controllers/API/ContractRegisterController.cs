using AutoMapper;
using InsuranceApp.Entities;
using InsuranceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using InsuranceApp.Repositories.Abstractions;
using System;
using InsuranceApp.Data;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Controllers.API
{
    [ApiController]
    [Route("api/register-contract")]
    public class ContractRegisterController : ControllerBase
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractRegisterController(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<ContractRegisterDto>> Get()
        {
            var contracts = _contractRepository.GetContractsRegister();

            if (contracts == null)
                return NotFound();

            var contractsRegisterDto = _mapper.Map<List<ContractRegisterDto>>(contracts);

            return Ok(contractsRegisterDto);
        }

        [HttpGet("{contractNumber}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ContractRegisterDto> Get(string contractNumber)
        {
            var contract = _contractRepository.GetContractRegisterById(contractNumber);

            if (contract == null)
                return NotFound();

            var contractRegisterDto = _mapper.Map<ContractRegisterDto>(contract);

            return Ok(contractRegisterDto);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] ContractRegisterDto contractRegisterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contract = _mapper.Map<Contract>(contractRegisterDto);

            _contractRepository.AddContractRegister(contract);

            var key = contract.ContractNr.Replace(" ", "-").ToLower();

            return Created("api/register-contract/" + key, null); 
        }

        [HttpPut("{contractNumber}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(string contractNumber, [FromBody] ContractRegisterDto contractRegisterDto)
        {
            var contract = _contractRepository.GetContractRegisterById(contractNumber);

            if (contract == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _contractRepository.EditContractRegister(contract, contractRegisterDto);

            return NoContent();
        }

        [HttpDelete("{contractNumber}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(string contractNumber)
        { 
            var contract = _contractRepository.GetContractRegisterById(contractNumber);

            if (contract == null)
                return NotFound();

            _contractRepository.DeleteContractRegister(contract);

            return NoContent();
        }

    }
}
