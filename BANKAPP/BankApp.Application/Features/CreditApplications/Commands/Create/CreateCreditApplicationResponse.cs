namespace BankApp.Application.Features.CreditApplications.Commands.Create
{
    public class CreateCreditApplicationResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CreditTypeId { get; set; }
        public decimal RequestedAmount { get; set; }
        public int Term { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
} 