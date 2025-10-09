namespace BankApp.Application.Features.CreditApplications.Queries.GetList
{
    public class GetListCreditApplicationResponse
    {
        public List<GetListCreditApplicationListItemDto> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
} 