using BankApp.Application.Features.CorporateCustomers.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Commands.Delete
{
    public class DeleteCorporateCustomerCommand : IRequest<DeletedCorporateCustomerResponse>
    {
        public Guid Id { get; set; }

        public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, DeletedCorporateCustomerResponse>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;
            private readonly CorporateCustomerBusinessRules _businessRules;

            public DeleteCorporateCustomerCommandHandler(
                ICorporateCustomerRepository corporateCustomerRepository,
                IMapper mapper,
                CorporateCustomerBusinessRules businessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<DeletedCorporateCustomerResponse> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.CorporateCustomerShouldExistWhenRequested(request.Id);

                var corporateCustomer = await _corporateCustomerRepository.GetAsync(c => c.Id == request.Id);
                await _corporateCustomerRepository.DeleteAsync(corporateCustomer);

                var response = _mapper.Map<DeletedCorporateCustomerResponse>(corporateCustomer);
                return response;
            }
        }
    }
} 