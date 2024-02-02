using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieRental.Core.Models;
using MovieRental.DAL.Contexts;

namespace MovieRental.DAL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services)
        {
            services.AddDbContext<MovieRentalDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.";
                opt.User.RequireUniqueEmail = true;

                opt.Password.RequireNonAlphanumeric = false;

                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.SignIn.RequireConfirmedAccount = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<MovieRentalDbContext>();

            return services;
        }
    }
}
