namespace BankApp.Application.Features.CreditApplications.Commands.Create
{
    public class CreatedCreditApplicationResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CreditTypeId { get; set; }
        public decimal RequestedAmount { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
} 