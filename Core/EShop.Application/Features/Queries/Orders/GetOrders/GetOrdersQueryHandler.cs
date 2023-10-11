using EShop.Application.Features.Queries.Orders.GetOrders;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Queries.Orders.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQueryRequest, GetOrdersQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrdersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetOrdersQueryResponse> Handle(GetOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = _unitOfWork.OrderReadRepository.GetAll(tracking: false);
            var totalCount = orders.Count();

            var selecetedOrders = orders
                        .OrderBy(o => o.CreatedTime)
                        .Skip(request.Size * request.Page)
                        .Take(request.Size)
                        .Select(o => new
                        {
                            o.Customer.Name,
                            o.Address
                        });

            return new() { Orders = selecetedOrders, TotalCount = totalCount };
        }
    }
}