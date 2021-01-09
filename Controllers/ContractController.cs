using AutoMapper;
using InsuranceApp.Entities;
using InsuranceApp.Data;
using InsuranceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using InsuranceApp.Repositories.Abstractions;

namespace InsuranceApp.Controllers
{
    [ApiController]
    [Route("api/contract")]
    public class ContractController : Controller
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ContractController> _logger;

        public ContractController(IContractRepository contractRepository, IMapper mapper, ILogger<ContractController> logger)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<ContractDto>> Get()
        {
            _logger.LogInformation("[Controller] - Get method started.");

            var contracts = _contractRepository.GetContracts();

            if (contracts == null)
                return NotFound();

            var contractsDto = _mapper.Map<List<ContractDto>>(contracts);

            return Ok(contractsDto);
        }

        [HttpGet("{contractNumber}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ContractDto> Get(string contractNumber)
        {
            _logger.LogInformation("[Controller] - Get details method started.");

            var contract = _contractRepository.GetContractById(contractNumber);

            if (contract == null)
                return NotFound();

            var contractDto = _mapper.Map<ContractDto>(contract);

            return Ok(contractDto);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] ContractDto contractModel)
        {
            _logger.LogInformation("[Controller] - Post method started.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contract = _mapper.Map<Contract>(contractModel);

            _contractRepository.AddContract(contract);

            var key = contract.ContractNr.Replace(" ", "-").ToLower();

            return Created("api/insurance/" + key, null);
        }

        [HttpPut("{contractNumber}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(string contractNumber, [FromBody] ContractDto contractModel)
        {
            _logger.LogInformation("[Controller] - Put method started.");

            var contract = _contractRepository.GetContractById(contractNumber);

            if (contract == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _contractRepository.EditContract(contract, contractModel);

            return NoContent();
        }

        [HttpDelete("{contractNumber}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(string contractNumber)
        {
            _logger.LogInformation("[Controller] - Delete method started.");

            var contract = _contractRepository.GetContractById(contractNumber);

            if (contract == null)
                return NotFound();

            _contractRepository.DeleteContract(contract);

            return NoContent();
        }

    }
}
