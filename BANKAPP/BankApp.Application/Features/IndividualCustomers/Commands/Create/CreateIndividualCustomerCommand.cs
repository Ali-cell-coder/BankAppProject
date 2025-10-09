using MediatR;
using System;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Create
{
    public class CreateIndividualCustomerCommand : IRequest<CreatedIndividualCustomerDto>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Nationality { get; set; }
        public required string Occupation { get; set; }
        public decimal MonthlyIncome { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
    }
} 