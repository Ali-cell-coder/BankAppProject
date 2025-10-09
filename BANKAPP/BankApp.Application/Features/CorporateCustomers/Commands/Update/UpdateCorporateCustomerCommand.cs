using BankApp.Application.Features.CorporateCustomers.Constants;
using BankApp.Application.Features.CorporateCustomers.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Update
{
    public class UpdateCorporateCustomerCommand : IRequest<UpdatedCorporateCustomerResponse>
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string CompanyType { get; set; }
        public string Sector { get; set; }
        public decimal AnnualRevenue { get; set; }
        public int EmployeeCount { get; set; }
        public string AuthorizedPersonName { get; set; }
        public string AuthorizedPersonTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, UpdatedCorporateCustomerResponse>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;
            private readonly CorporateCustomerBusinessRules _businessRules;

            public UpdateCorporateCustomerCommandHandler(
                ICorporateCustomerRepository corporateCustomerRepository,
                IMapper mapper,
                CorporateCustomerBusinessRules businessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedCorporateCustomerResponse> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.CorporateCustomerShouldExistWhenRequested(request.Id);
                await _businessRules.CorporateCustomerTaxNumberShouldBeUnique(request.TaxNumber);
                _businessRules.ValidateTaxNumber(request.TaxNumber);
                _businessRules.ValidateAnnualRevenue(request.AnnualRevenue);
                _businessRules.ValidateEmployeeCount(request.EmployeeCount);

                var corporateCustomer = await _corporateCustomerRepository.GetAsync(c => c.Id == request.Id);
                _mapper.Map(request, corporateCustomer);
                var updatedCorporateCustomer = await _corporateCustomerRepository.UpdateAsync(corporateCustomer);

                var response = _mapper.Map<UpdatedCorporateCustomerResponse>(updatedCorporateCustomer);
                return response;
            }
        }
    }
} 