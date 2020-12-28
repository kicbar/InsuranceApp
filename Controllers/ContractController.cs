using AutoMapper;
using InsuranceApp.Entities;
using InsuranceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceApp.Controllers
{
    [ApiController]
    [Route("api/Insurance")]
    public class ContractController : Controller
    {
        private readonly InsuranceDbContext _insuranceDbContext;
        private readonly IMapper _mapper;

        public ContractController(InsuranceDbContext insuranceDbContext, IMapper mapper)
        {
            _insuranceDbContext = insuranceDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ContractDto>> Get()
        {
            var contracts = _insuranceDbContext.Contracts.ToList();
            var contractsDto = _mapper.Map<List<ContractDto>>(contracts);

            return Ok(contractsDto);
        }

        [HttpGet("{contractNumber}")]
        public ActionResult<ContractDto> Get(string contractNumber)
        {
            var contract = _insuranceDbContext.Contracts.FirstOrDefault(c => c.ContractNr == contractNumber);

            if (contract == null)
                return NotFound();

            var contractDto = _mapper.Map<ContractDto>(contract);

            return Ok(contractDto);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ContractDto contractModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contract = _mapper.Map<Contract>(contractModel);

            _insuranceDbContext.Contracts.Add(contract);
            _insuranceDbContext.SaveChanges();

            var key = contract.ContractNr.Replace(" ", "-").ToLower();

            return Created("api/insurance/" + key, null);
        }

        [HttpPut("{contractNumber}")]
        public ActionResult Put(string contractNumber, [FromBody] ContractDto contractModel)
        {
            var contract = _insuranceDbContext.Contracts.FirstOrDefault(c => c.ContractNr == contractNumber);

            if (contract == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            contract.ContractNr = contractModel.ContractNr;
            contract.InsuredPerson = contractModel.InsuredPerson;
            contract.InsuranceType = contractModel.InsuranceType;
            contract.StartDate = contractModel.StartDate;

            _insuranceDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{contractNumber}")]
        public ActionResult Delete(string contractNumber)
        {
            var contract = _insuranceDbContext.Contracts.FirstOrDefault(c => c.ContractNr == contractNumber);

            if (contract == null)
                return NotFound();

            _insuranceDbContext.Contracts.Remove(contract);
            _insuranceDbContext.SaveChanges();

            return NoContent();
        }
    }
}
