using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using EShop.Application.Repositories.ProductRepository;
using EShop.Persistence.Repositories.ProductRepositoy;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Persistence.Repositories.CustomerRepository;
using EShop.Application.Repositories.OrderRepository;
using EShop.Persistence.Repositories.OrderRepository;
using EShop.Application.Repositories;
using EShop.Persistence.Repositories;
using EShop.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<EShopDbContext>(options => options.UseSqlServer(Configuration.ConnectionString, op => options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)), ServiceLifetime.Transient);

            services.AddTransient<IProductReadRepository, ProductReadRepository>();
            services.AddTransient<IProductWriteRepository, ProductWriteRepository>();

            services.AddTransient<ICustomerReadRepository, CustomerReadRepository>();
            services.AddTransient<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddTransient<IOrderReadRepository, OrderReadRepository>();
            services.AddTransient<IOrderWriteRepository, OrderWriteRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}