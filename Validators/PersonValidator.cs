using FluentValidation;
using InsuranceApp.Data;
using InsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Validators
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator(InsuranceDbContext insuranceDbContext)
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.FirstName).MinimumLength(3);
            RuleFor(p => p.FirstName).MaximumLength(40);
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.LastName).MinimumLength(3);
            RuleFor(p => p.LastName).MaximumLength(40);
            RuleFor(p => p.Pesel).NotEmpty();
            RuleFor(p => p.Pesel).Length(11);
            RuleFor(p => p.Pesel).Custom((value, context) =>
            {
                var peselAlredyExist = insuranceDbContext.Persons.Any(x => x.Pesel == value);
                if (peselAlredyExist)
                    context.AddFailure("Pesel", "This pesel already exist.");
            });
        }

    }
}
