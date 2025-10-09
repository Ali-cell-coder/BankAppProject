using System;

namespace BankApp.Domain.Entities
{
    public class IndividualCreditType : CreditType
    {
        public decimal MaxMonthlyIncome { get; set; }
        public decimal MinCreditScore { get; set; }
        public bool RequiresCollateral { get; set; }
        public required string CollateralType { get; set; } // RealEstate, Vehicle, etc.
    }
} 