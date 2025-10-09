using MediatR;
using System;

namespace BankApp.Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
} 