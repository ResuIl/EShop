namespace EShop.Application.Features.Queries.Customers.GetCustomers
{
    public class GetCustomersQueryResponse
    {
        public int TotalCount { get; set; }
        public object Customers { get; set; }
    }
}