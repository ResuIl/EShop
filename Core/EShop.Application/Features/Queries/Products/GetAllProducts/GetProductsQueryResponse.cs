namespace EShop.Application.Features.Queries.Products.GetAllProducts
{
    public class GetProductsQueryResponse
    {
        public int TotalCount { get; set; }
        public object Products { get; set; }
    }
}