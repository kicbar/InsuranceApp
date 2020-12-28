using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Controllers
{
    [ApiController]
    [Route("api/Insurance")]
    public class ContractController : Controller
    {
        private readonly InsuranceDbContext _insuranceDbContext;

        public ContractController(InsuranceDbContext insuranceDbContext)
        {
            _insuranceDbContext = insuranceDbContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var contracts = _insuranceDbContext.Contracts;
            return Ok(contracts);
        }

        [HttpGet("{contractNum}")]
        public ActionResult Get(string contractNum)
        {
            var contract = _insuranceDbContext.Contracts.FirstOrDefault(c => c.ContractNr == contractNum);
            return Ok(contract);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Contract contractModel)
        {
            _insuranceDbContext.Contracts.Add(contractModel);
            _insuranceDbContext.SaveChanges();

            var key = contractModel.ContractNr.Replace(" ", "-").ToLower();

            return Created("api/insurance/" + key, null);
        }

        [HttpPut("{contractNum}")]
        public ActionResult Put(string contractNum, [FromBody] Contract contractModel)
        {
            var contract = _insuranceDbContext.Contracts.FirstOrDefault(c => c.ContractNr == contractNum);

            if (contract == null)
                return NotFound();

            contract.ContractNr = contractModel.ContractNr;
            contract.InsuredPerson = contractModel.InsuredPerson;
            contract.InsuranceType = contractModel.InsuranceType;
            contract.StartDate = contractModel.StartDate;

            _insuranceDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{contractNum}")]
        public ActionResult Delete(string contractNum)
        {
            var contract = _insuranceDbContext.Contracts.FirstOrDefault(c => c.ContractNr == contractNum);
            _insuranceDbContext.Contracts.Remove(contract);
            _insuranceDbContext.SaveChanges();

            return NoContent();
        }

    }
}
