using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Models
{
    public class ContractDto
    {
        [Required]
        [MinLength(5)]
        public string ContractNr { get; set; }
        [Required]
        [MinLength(10)]
        public string InsuredPerson { get; set; }
        [Required]
        public string InsuranceType { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
    }
}
