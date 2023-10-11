using EShop.Application.Repositories;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Orders.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddOrderCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerReadRepository.GetAsync(request.CustomerId);
           
            if (customer is not null)
            {
                var order = new Order() { Address = request.Address, Description = request.Description, Customer = customer };
                await _unitOfWork.OrderWriteRepository.AddAsync(order);
                await _unitOfWork.OrderWriteRepository.SaveChangesAsync();
            }
            
            return new();
        }
    }
}