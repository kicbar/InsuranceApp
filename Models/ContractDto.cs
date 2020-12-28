using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Models
{
    public class ContractDto
    {
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string ContractNr { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 8)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string InsuredPerson { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 1)]
        public string InsuranceType { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}
