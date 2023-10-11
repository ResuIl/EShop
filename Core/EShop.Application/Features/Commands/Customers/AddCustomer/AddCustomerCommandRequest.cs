using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Customers.AddCustomer
{
    public class AddCustomerCommandRequest : IRequest<AddCustomerCommandResponse>
    {
        public string Name { get; set; }
    }
}