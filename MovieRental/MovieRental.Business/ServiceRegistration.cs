using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MovieRental.Business.Profiles;
using MovieRental.Business.Services.Implements;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Core.Models;
using MovieRental.DAL.Contexts;

namespace MovieRental.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            //services.AddHttpContextAccessor();
            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(typeof(MovieMappingProfile));

            return services;
        }
    }
}
