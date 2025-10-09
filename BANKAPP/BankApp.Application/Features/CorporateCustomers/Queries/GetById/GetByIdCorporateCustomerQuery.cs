using MediatR;

namespace BankApp.Application.Features.CorporateCustomers.Queries.GetById
{
    public class GetByIdCorporateCustomerQuery : IRequest<GetByIdCorporateCustomerResponse>
    {
        public Guid Id { get; set; }
    }
} 