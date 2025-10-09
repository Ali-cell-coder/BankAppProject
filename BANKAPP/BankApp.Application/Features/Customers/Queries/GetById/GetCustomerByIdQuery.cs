using MediatR;
using System;

namespace BankApp.Application.Features.Customers.Queries.GetById
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
    }

    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
        // Add other properties as needed
    }
} 