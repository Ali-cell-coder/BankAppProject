namespace BankApp.Application.Features.CorporateCustomers.Queries.GetById
{
    public class GetByIdCorporateCustomerResponse
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string CompanyType { get; set; }
        public string Sector { get; set; }
        public decimal AnnualRevenue { get; set; }
        public int EmployeeCount { get; set; }
        public string AuthorizedPersonName { get; set; }
        public string AuthorizedPersonTitle { get; set; }
    }
} 