using EShop.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Customers.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQueryRequest, GetCustomersQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomersQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<GetCustomersQueryResponse> Handle(GetCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = _unitOfWork.CustomerReadRepository.GetAll(tracking: false);
            var totalCount = customers.Count();
            var selecetedCustomers = customers
                        .OrderBy(c => c.CreatedTime)
                        .Skip(request.Size * request.Page)
                        .Take(request.Size)
                        .Select(c => new
                        {
                            c.Id,
                            c.Name
                        });

            return new() { Customers = selecetedCustomers, TotalCount = totalCount };
        }
    }
}