using AutoMapper;
using BankApp.Domain.Entities;
using BankApp.Application.Features.CreditTypes.Queries.GetList;

namespace BankApp.Application.Features.CreditTypes.Mapping
{
    public class CreditTypeProfile : Profile
    {
        public CreditTypeProfile()
        {
            CreateMap<CreditType, CreditTypeDto>();
        }
    }
} 