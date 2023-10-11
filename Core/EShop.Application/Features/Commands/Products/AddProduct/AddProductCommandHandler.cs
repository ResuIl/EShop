using EShop.Application.Repositories.ProductRepository;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Products.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IProductWriteRepository repository;

        public AddProductCommandHandler(IProductWriteRepository repository) => this.repository = repository;

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Desc,
                Price = request.Price,
                Stock = request.Stock,
            };

            await repository.AddAsync(product);
            await repository.SaveChangesAsync();

            return new();
        }
    }
}