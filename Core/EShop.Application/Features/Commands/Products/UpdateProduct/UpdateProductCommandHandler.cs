using EShop.Application.Repositories;
using EShop.Application.Repositories.ProductRepository;
using MediatR;

namespace EShop.Application.Features.Commands.Products.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductReadRepository.GetAsync(request.Id);
          
            if (product is not null)
            {
                product.Description = request.Description;
                product.Price = request.Price;
                product.Stock = request.Stock;
                product.Name = request.Name;

                _unitOfWork.ProductWriteRepository.Update(product);
                await _unitOfWork.ProductWriteRepository.SaveChangesAsync();
            
                return new() { Result = true };
            }
            
            return new() { Result = false };
        }
    }
}