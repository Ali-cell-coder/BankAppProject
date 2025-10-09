using AutoMapper;
using BankApp.Application.Services.Repositories;
using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Queries.GetById
{
    public class GetByIdCorporateCustomerQueryHandler : IRequestHandler<GetByIdCorporateCustomerQuery, GetByIdCorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;

        public GetByIdCorporateCustomerQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCorporateCustomerResponse> Handle(GetByIdCorporateCustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _corporateCustomerRepository.GetAsync(x => x.Id == request.Id);
            return _mapper.Map<GetByIdCorporateCustomerResponse>(entity);
        }
    }
} 