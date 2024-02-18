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
            services.AddDbContext<MovieRentalDbContext>(opt => opt.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.";
                opt.User.RequireUniqueEmail = false;

                opt.Password.RequireNonAlphanumeric = false;

                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.SignIn.RequireConfirmedAccount = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<MovieRentalDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.AccessDeniedPath = "/auth/AccessDenied";
                opt.LogoutPath = "/auth/logout";
                opt.LoginPath = "/auth/Login";

                opt.Cookie.Name = "IdentityCookie";
                opt.ExpireTimeSpan = TimeSpan.FromDays(1);

                opt.SlidingExpiration = true;
            });

            return services;
        }
    }
}
