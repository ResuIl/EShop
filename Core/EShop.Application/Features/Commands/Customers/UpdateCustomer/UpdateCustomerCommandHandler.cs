using EShop.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerReadRepository.GetAsync(request.Id);
            
            if (customer is not null)
            {
                customer.Name = request.Name;
                _unitOfWork.CustomerWriteRepository.Update(customer);
                await _unitOfWork.CustomerWriteRepository.SaveChangesAsync();
               
                return new() { Result = true };
            }

            return new() { Result = false };
        }
    }
}