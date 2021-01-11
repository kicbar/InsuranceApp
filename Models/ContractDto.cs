using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Models
{
    public class ContractDto
    {
        public string ContractNr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InsuranceType { get; set; }
        public string Value { get; set; }
        public int Status { get; set; }
    }
}
