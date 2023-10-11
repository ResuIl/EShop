using EShop.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductReadRepository.GetAsync(request.Id);
          
            if (product != null)
            {
                _unitOfWork.ProductWriteRepository.Remove(product);
                await _unitOfWork.ProductWriteRepository.SaveChangesAsync();
               
                return new() { Result = true };
            }

            return new() { Result = false };
        }
    }
}