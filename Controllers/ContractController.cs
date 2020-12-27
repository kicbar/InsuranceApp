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
    }
}
