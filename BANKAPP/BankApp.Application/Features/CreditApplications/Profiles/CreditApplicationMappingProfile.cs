using AutoMapper;
using BankApp.Application.Features.CreditApplications.Commands.Create;
using BankApp.Application.Features.CreditApplications.Queries.GetList;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CreditApplications.Profiles
{
    public class CreditApplicationMappingProfile : Profile
    {
        public CreditApplicationMappingProfile()
        {
            CreateMap<CreditApplication, CreateCreditApplicationResponse>();
            
            CreateMap<CreditApplication, GetListCreditApplicationListItemDto>()
                .ForMember(dest => dest.CreditTypeName, opt => opt.MapFrom(src => src.CreditType.Name));
        }
    }
} 