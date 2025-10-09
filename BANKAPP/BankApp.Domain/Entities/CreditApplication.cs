using System;
using BankApp.Core.Repositories;

namespace BankApp.Domain.Entities
{
    public class CreditApplication : Entity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid CreditTypeId { get; set; }
        public decimal RequestedAmount { get; set; }
        public int Term { get; set; } // Ay cinsinden
        public string Purpose { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public DateTime ApplicationDate { get; set; }
        public string? RejectionReason { get; set; }

        // Navigation properties
     
        public CreditType CreditType { get; set; }
    }
} 