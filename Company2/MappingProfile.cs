using AutoMapper;
using Entities.Models;
using Shared.DTO;

namespace Company2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ForCtorParam("FullAddress",
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<CompanyForCreationDto, Company>().ReverseMap();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<Employee, EmployeeForCreationDto>().ReverseMap();
            CreateMap<CompanyDto, CompanyForCreationDto>().ReverseMap();

            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

            CreateMap<CompanyForUpdateDto, Company>().ReverseMap();

            CreateMap<UserForRegistrationDto, User>().ReverseMap();

            CreateMap<UserForAuthenticationDto, User>().ReverseMap();
        }
    }
}
