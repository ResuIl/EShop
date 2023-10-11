using EShop.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderReadRepository.GetAsync(request.Id);

            if (order is not null)
            {
                order.Description = request.Description;
                order.Address = request.Address;
                if (request.CustomerId is not null)
                {
                    var customer = await _unitOfWork.CustomerReadRepository.GetAsync(request.CustomerId);
                    if (customer is not null) order.Customer = customer;
                }

                return new() { Result = true };
            }

            return new() { Result = false };
        }
    }
}