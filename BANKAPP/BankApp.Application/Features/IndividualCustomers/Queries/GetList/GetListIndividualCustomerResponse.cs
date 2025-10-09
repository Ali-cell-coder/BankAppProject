namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList
{
    public class GetListIndividualCustomerResponse
    {
        public List<GetListIndividualCustomerListItemDto> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }

    public class GetListIndividualCustomerListItemDto
    {
        public Guid Id { get; set; }
        public string CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        
    }
} 