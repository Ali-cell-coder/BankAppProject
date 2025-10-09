using System;
using BankApp.Core.Repositories;

namespace BankApp.Domain.Entities
{
    public class CreditType : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int MinTerm { get; set; } // Ay cinsinden
        public int MaxTerm { get; set; } // Ay cinsinden
        public decimal InterestRate { get; set; }
        public decimal BaseInterestRate { get; set; }
        public string CreditTypeCategory { get; set; } // Individual, Corporate
    }
} 