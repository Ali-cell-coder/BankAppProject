using AutoMapper;
using BankApp.Application.Features.IndividualCustomers.Commands.Create;
using BankApp.Application.Features.IndividualCustomers.Commands.Update;
using BankApp.Application.Features.IndividualCustomers.Commands.Delete;
using BankApp.Application.Features.IndividualCustomers.Queries.GetById;
using BankApp.Application.Features.IndividualCustomers.Queries.GetList;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.IndividualCustomers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IndividualCustomer, GetByIdIndividualCustomerResponse>().ReverseMap();
            CreateMap<IndividualCustomer, GetListIndividualCustomerListItemDto>().ReverseMap();
            CreateMap<IndividualCustomer, CreateIndividualCustomerCommand>().ReverseMap();
            CreateMap<IndividualCustomer, CreatedIndividualCustomerResponse>().ReverseMap();
            CreateMap<IndividualCustomer, UpdateIndividualCustomerCommand>().ReverseMap();
            CreateMap<IndividualCustomer, UpdatedIndividualCustomerResponse>().ReverseMap();
            CreateMap<IndividualCustomer, DeleteIndividualCustomerCommand>().ReverseMap();
            CreateMap<IndividualCustomer, DeletedIndividualCustomerResponse>().ReverseMap();
        }
    }
} 