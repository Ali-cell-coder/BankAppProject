using System;
using BankApp.Core.Repositories;

namespace BankApp.Domain.Entities
{
    public class IndividualCustomer : Entity<Guid>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Occupation { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
} 