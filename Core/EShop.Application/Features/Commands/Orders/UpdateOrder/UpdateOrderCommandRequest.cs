using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommandRequest : IRequest<UpdateOrderCommandResponse>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string CustomerId { get; set; }
    }
}