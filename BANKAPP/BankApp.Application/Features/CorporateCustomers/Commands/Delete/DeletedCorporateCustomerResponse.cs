namespace BankApp.Application.Features.CorporateCustomers.Commands.Delete
{
    public class DeletedCorporateCustomerResponse
    {
        public Guid Id { get; set; }
        public string CustomerNumber { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string CompanyType { get; set; }
        public string Sector { get; set; }
        public decimal AnnualRevenue { get; set; }
        public int EmployeeCount { get; set; }
        public string AuthorizedPersonName { get; set; }
        public string AuthorizedPersonTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public decimal CreditScore { get; set; }
    }
} 