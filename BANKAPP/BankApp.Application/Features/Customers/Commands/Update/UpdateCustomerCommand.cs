using MediatR;
using System;

namespace BankApp.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
        // Add other properties as needed
    }
} 