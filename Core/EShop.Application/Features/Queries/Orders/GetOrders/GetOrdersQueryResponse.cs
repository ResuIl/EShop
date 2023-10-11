namespace EShop.Application.Features.Queries.Orders.GetOrders
{
    public class GetOrdersQueryResponse
    {
        public int TotalCount { get; set; }
        public object Orders { get; set; }
    }
}