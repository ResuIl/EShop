using EShop.Application.Repositories;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Customers.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandRequest, AddCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCustomerCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<AddCustomerCommandResponse> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = new Customer() { Name = request.Name };
            await _unitOfWork.CustomerWriteRepository.AddAsync(customer);
            await _unitOfWork.CustomerWriteRepository.SaveChangesAsync();

            return new();
        }
    }
}