using System;

namespace InsuranceApp.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string ContractNr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InsuranceType { get; set; }
        public string Value { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public int InsuredId { get; set; }
        public virtual Person Person { get; set; }

    }
}
