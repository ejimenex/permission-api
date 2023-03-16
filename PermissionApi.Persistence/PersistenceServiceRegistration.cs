using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermissionApi.Application.Contract.Persistence;
using PermissionApi.Domain.Entities;
using PermissionApi.Persistence.Repositories;

namespace PermissionApi.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PermissionDataContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("Context")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAsyncRepository<Permission>, PermissionRepository>();
            return services;
        }
    }
}
