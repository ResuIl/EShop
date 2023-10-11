using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.OrderRepository;
using EShop.Application.Repositories.ProductRepository;

namespace EShop.Application.Repositories
{
    public interface IUnitOfWork
    {
        IProductReadRepository ProductReadRepository { get; }
        IProductWriteRepository ProductWriteRepository { get; }
        IOrderReadRepository OrderReadRepository { get; }
        IOrderWriteRepository OrderWriteRepository { get; }
        ICustomerReadRepository CustomerReadRepository { get; }
        ICustomerWriteRepository CustomerWriteRepository { get; }
    }
}