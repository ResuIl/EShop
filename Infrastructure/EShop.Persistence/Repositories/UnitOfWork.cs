using EShop.Application.Repositories;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.OrderRepository;
using EShop.Application.Repositories.ProductRepository;
using EShop.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EShopDbContext _context;

        public IProductReadRepository ProductReadRepository { get; }

        public IProductWriteRepository ProductWriteRepository { get; }

        public IOrderReadRepository OrderReadRepository { get; }

        public IOrderWriteRepository OrderWriteRepository { get; }

        public ICustomerReadRepository CustomerReadRepository { get; }

        public ICustomerWriteRepository CustomerWriteRepository { get; }

        public UnitOfWork(EShopDbContext context, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _context = context;
            ProductReadRepository = productReadRepository;
            ProductWriteRepository = productWriteRepository;
            OrderReadRepository = orderReadRepository;
            OrderWriteRepository = orderWriteRepository;
            CustomerReadRepository = customerReadRepository;
            CustomerWriteRepository = customerWriteRepository;
        }
    }
}