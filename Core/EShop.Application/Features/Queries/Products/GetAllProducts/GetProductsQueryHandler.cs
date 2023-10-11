using EShop.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Products.GetAllProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, GetProductsQueryResponse>
    {
        private readonly IProductReadRepository repository;

        public GetProductsQueryHandler(IProductReadRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetProductsQueryResponse> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = repository.GetAll(tracking: false);
            var totalCount = products.Count();

            var selecetedProducts = products
                        .OrderBy(p => p.CreatedTime)
                        .Skip(request.Size * request.Page)
                        .Take(request.Size)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            p.Description,
                            p.Stock
                        });

            return new() { Products = selecetedProducts, TotalCount = totalCount };


        }
    }
}
