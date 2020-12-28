using System;

namespace InsuranceApp.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string ContractNr { get; set; }
        public string InsuredPerson { get; set; }
        public string InsuranceType { get; set; }
        public DateTime StartDate { get; set; }
    }
}
