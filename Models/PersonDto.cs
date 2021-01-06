using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Models
{
    public class PersonDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Nationality { get; set; }
    }
}
