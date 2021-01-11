using AutoMapper;
using InsuranceApp.Entities;
using InsuranceApp.Models;

namespace InsuranceApp.Profiles
{
    public class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            CreateMap<Contract, ContractRegisterDto>()
                .ForMember(c => c.FirstName, map => map.MapFrom(contract => contract.Person.FirstName))
                .ForMember(c => c.LastName, map => map.MapFrom(contract => contract.Person.LastName))
                .ForMember(c => c.Pesel, map => map.MapFrom(contract => contract.Person.Pesel))
                .ForMember(c => c.Nationality, map => map.MapFrom(contract => contract.Person.Nationality))
                .ReverseMap();
                
            CreateMap<ContractDto, Contract>()
                .ReverseMap();

            CreateMap<PersonDto, Person>()
                .ReverseMap();
        }
    }
}
