using EShop.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Orders.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderReadRepository.GetAsync(request.Id);
        
            if (order is not null)
            {
                _unitOfWork.OrderWriteRepository.Remove(order);
                await _unitOfWork.OrderWriteRepository.SaveChangesAsync();
            
                return new() { Result = true };
            }
            
            return new() { Result = false };
        }
    }
}