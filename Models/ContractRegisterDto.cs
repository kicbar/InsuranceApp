using System;

namespace InsuranceApp.Models
{
    public class ContractRegisterDto
    {
        public string ContractNr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InsuranceType { get; set; }
        public string Value { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Nationality { get; set; }
    }
}
