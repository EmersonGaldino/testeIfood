using ifood.test.galdino.repository.Context;
using ifood.test.galdino.repository.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ifood.test.galdino.repository.Interface.Product;
using ifood.test.galdino.repository.Interface.User;
using ifood.test.galdino.repository.Repositories.Product;
using ifood.test.galdino.repository.Repositories.User;
using ifood.test.galdino.service.Interface.Base;
using ifood.test.galdino.service.Interface.Product;
using ifood.test.galdino.service.Interface.User;
using ifood.test.galdino.service.Product;
using ifood.test.galdino.service.User;
using Npgsql;

namespace ifood.test.galdino.api.Configurations.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext>();
            services.AddScoped<IDbConnection>(sp =>
            {
                var connectionString = configuration.GetConnectionString("SqlConnectionString");
                return new NpgsqlConnection(connectionString);
            });

            services.AddScoped<UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var implementationsType = typeof(DependencyInjectionExtensions).Assembly.GetTypes()
                .Where(t => typeof(IRepository).IsAssignableFrom(t) &&
                            t.BaseType != null
                ).ToList();

            foreach (var item in implementationsType)
                services.AddScoped(item);

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var implementationsType = typeof(DependencyInjectionExtensions).Assembly.GetTypes()
                .Where(t => typeof(IService).IsAssignableFrom(t) &&
                            t.BaseType != null);

            foreach (var item in implementationsType)
                services.AddScoped(item);

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
