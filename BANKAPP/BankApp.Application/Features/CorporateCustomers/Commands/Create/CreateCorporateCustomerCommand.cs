using BankApp.Application.Features.CorporateCustomers.Constants;
using BankApp.Application.Features.CorporateCustomers.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Create
{
    public class CreateCorporateCustomerCommand : IRequest<CreatedCorporateCustomerResponse>
    {
        public required string CompanyName { get; set; }
        public required string TaxNumber { get; set; }
        public required string TaxOffice { get; set; }
        public required string CompanyType { get; set; }
        public required string Sector { get; set; }
        public decimal AnnualRevenue { get; set; }
        public int EmployeeCount { get; set; }
        public required string AuthorizedPersonName { get; set; }
        public required string AuthorizedPersonTitle { get; set; }

        public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreatedCorporateCustomerResponse>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;
            private readonly CorporateCustomerBusinessRules _businessRules;

            public CreateCorporateCustomerCommandHandler(
                ICorporateCustomerRepository corporateCustomerRepository,
                IMapper mapper,
                CorporateCustomerBusinessRules businessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreatedCorporateCustomerResponse> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.CorporateCustomerTaxNumberShouldBeUnique(request.TaxNumber);
                _businessRules.ValidateTaxNumber(request.TaxNumber);
                _businessRules.ValidateAnnualRevenue(request.AnnualRevenue);
                _businessRules.ValidateEmployeeCount(request.EmployeeCount);

                var corporateCustomer = _mapper.Map<CorporateCustomer>(request);
                var createdCorporateCustomer = await _corporateCustomerRepository.AddAsync(corporateCustomer);

                var response = _mapper.Map<CreatedCorporateCustomerResponse>(createdCorporateCustomer);
                return response;
            }
        }
    }
} 