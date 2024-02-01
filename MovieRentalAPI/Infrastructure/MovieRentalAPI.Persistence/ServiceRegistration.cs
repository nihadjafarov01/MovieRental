using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieRentalAPI.Persistence.Contexts;

namespace MovieRentalAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MovieRentalAPIDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));

            return services;
        }
    }
}
