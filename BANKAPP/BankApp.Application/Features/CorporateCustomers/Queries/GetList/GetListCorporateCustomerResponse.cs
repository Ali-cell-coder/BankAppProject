namespace BankApp.Application.Features.CorporateCustomers.Queries.GetList
{
    public class GetListCorporateCustomerResponse
    {
        public List<GetListCorporateCustomerListItemDto> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
} 