using Microsoft.Extensions.DependencyInjection;
using MovieRental.Business.Profiles;
using MovieRental.Business.Repositories.Implements;
using MovieRental.Business.Repositories.Interfaces;
using MovieRental.Business.Services.Implements;
using MovieRental.Business.Services.Interfaces;

namespace MovieRental.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, string rootpath)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IWatchListRepository, WatchListRepository>();
            services.AddScoped<IWatchListMovieRepository, WatchListMovieRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILayoutService, LayoutService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IWatchListService, WatchListService>();
            services.AddScoped<IWatchListMovieService, WatchListMovieService>();
            services.AddScoped<ISliderService, SliderService>();

            services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new UserMappingProfile(rootpath));
            });

            services.AddAutoMapper(typeof(MovieMappingProfile));

            return services;
        }
    }
}
