using AutoMapper;
using InsuranceApp.Entities;
using InsuranceApp.Models;

namespace InsuranceApp.Profiles
{
    public class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            CreateMap<ContractDto, Contract>()
                .ReverseMap();
        }
    }
}
