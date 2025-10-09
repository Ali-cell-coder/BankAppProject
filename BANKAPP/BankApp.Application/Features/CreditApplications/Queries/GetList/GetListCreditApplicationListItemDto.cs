namespace BankApp.Application.Features.CreditApplications.Queries.GetList
{
    public class GetListCreditApplicationListItemDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerNumber { get; set; }
        public Guid CreditTypeId { get; set; }
        public string CreditTypeName { get; set; }
        public decimal RequestedAmount { get; set; }
        public int Term { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
} 