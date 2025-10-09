using System;

namespace BankApp.Domain.Entities
{
    public class CorporateCreditType : CreditType
    {
        public decimal MinAnnualRevenue { get; set; }
        public int MinYearsInBusiness { get; set; }
        public bool RequiresFinancialStatements { get; set; }
        public string BusinessType { get; set; } // SME, Large, etc.
        public bool RequiresGuarantee { get; set; }
    }
} 