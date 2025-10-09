using AutoMapper;
using BankApp.Application.Features.CorporateCustomers.Commands.Create;
using BankApp.Application.Features.CorporateCustomers.Commands.Update;
using BankApp.Application.Features.CorporateCustomers.Commands.Delete;
using BankApp.Application.Features.CorporateCustomers.Queries.GetById;
using BankApp.Application.Features.CorporateCustomers.Queries.GetList;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CorporateCustomers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CorporateCustomer, GetByIdCorporateCustomerResponse>().ReverseMap();
            CreateMap<CorporateCustomer, GetListCorporateCustomerListItemDto>().ReverseMap();
            CreateMap<CorporateCustomer, CreateCorporateCustomerCommand>().ReverseMap();
            CreateMap<CorporateCustomer, CreatedCorporateCustomerResponse>().ReverseMap();
            CreateMap<CorporateCustomer, UpdateCorporateCustomerCommand>().ReverseMap();
            CreateMap<CorporateCustomer, UpdatedCorporateCustomerResponse>().ReverseMap();
            CreateMap<CorporateCustomer, DeleteCorporateCustomerCommand>().ReverseMap();
            CreateMap<CorporateCustomer, DeletedCorporateCustomerResponse>().ReverseMap();
        }
    }
} 