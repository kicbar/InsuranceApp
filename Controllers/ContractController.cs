using AutoMapper;
using InsuranceApp.Entities;
using InsuranceApp.DataAccess;
using InsuranceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ContractController> _logger;

        public ContractController(InsuranceDbContext insuranceDbContext, IMapper mapper, ILogger<ContractController> logger)
        {
            _insuranceDbContext = insuranceDbContext;
            _mapper = mapper;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into ContractController");
        }

        [HttpGet]
        public ActionResult<List<ContractDto>> Get()
        {
            _logger.LogInformation("Get method started.");

            var contracts = _insuranceDbContext.Contracts.ToList();
            var contractsDto = _mapper.Map<List<ContractDto>>(contracts);

            return Ok(contractsDto);
        }

        [HttpGet("{contractNumber}")]
        public ActionResult<ContractDto> Get(string contractNumber)
        {
            _logger.LogInformation("Get details method started.");

            var contract = _insuranceDbContext.Contracts.FirstOrDefault(c => c.ContractNr == contractNumber);

            if (contract == null)
                return NotFound();

            var contractDto = _mapper.Map<ContractDto>(contract);

            return Ok(contractDto);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ContractDto contractModel)
        {
            _logger.LogInformation("Post method started.");

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
            _logger.LogInformation("Put method started.");

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
            _logger.LogInformation("Delete method started.");

            var contract = _insuranceDbContext.Contracts.FirstOrDefault(c => c.ContractNr == contractNumber);

            if (contract == null)
                return NotFound();

            _insuranceDbContext.Contracts.Remove(contract);
            _insuranceDbContext.SaveChanges();

            return NoContent();
        }
    }
}
