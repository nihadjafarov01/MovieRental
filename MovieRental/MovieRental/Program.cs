using MovieRental.DAL;
using MovieRental.Business;
using MovieRental.Business.Hubs;

namespace MovieRental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDALServices();
            builder.Services.AddBusinessServices();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSignalR();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapHub<ChatHub>("/chatHub");

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Movie}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "userProfile",
                pattern: "user/profile/{username}",
                defaults: new { controller = "User", action = "Profile" });

            app.MapControllerRoute(
                name: "post",
                pattern: "community/post/{postId}",
                defaults: new { controller = "Community", action = "Post" });

            app.MapControllerRoute(
                name: "posts",
                pattern: "community/{tagTitle}/posts",
                defaults: new { controller = "Community", action = "Posts" });


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}