using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieRental.Areas.Admin.ViewModels.UserVMs;
using MovieRental.Business.Helpers;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.UserVMs;
using MovieRental.Core.Models;
using MovieRental.DAL.Contexts;
using System.Security.Claims;

namespace MovieRental.Business.Services.Implements
{
    public class UserService : IUserService
    {
        IMapper _mapper { get; }
        UserManager<AppUser> _userManager { get; }
        private readonly IHttpContextAccessor _httpContext;
        readonly MovieRentalDbContext _context;

        public UserService(UserManager<AppUser> userManager, IMapper mapper, IHttpContextAccessor httpContext, MovieRentalDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContext = httpContext;
            _context = context;
        }

        public IEnumerable<UserVM> GetAll()
        {
            var users = _userManager.Users;
            var rdata = _mapper.Map<IEnumerable<UserVM>>(users);
            return rdata;
        }

        public async Task<MyProfileVM> GetMyProfileAsync()
        {
            string username = _httpContext.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var ruser = _mapper.Map<MyProfileVM>(user);
            return ruser;
        }

        public async Task<UserVM> GetUserVMAsync()
        {
            string username = _httpContext.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var vm = _mapper.Map<UserVM>(user);
            return vm;
        }

        public async Task<string> GetUserIdAsync()
        {
            string username = _httpContext.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            return user.Id;
        }

        public async Task<UserProfileVM> GetUserByUsernameAsync(string username)
        {
            AppUser user = await _context.Users.Include(u => u.WatchList).ThenInclude(u => u.WatchListMovies).ThenInclude(u => u.Movie).SingleOrDefaultAsync(u => u.UserName == username);
            UserProfileVM vm = _mapper.Map<UserProfileVM>(user);
            return vm;
        }

        public async Task<AppUser> GetCurrentUserAsync()
        {
            string username = _httpContext.HttpContext.User.Identity.Name;
            //var user = await _userManager.FindByNameAsync(username);
            AppUser user = await _context.Users.Include(u => u.WatchList).ThenInclude(u => u.WatchListMovies).ThenInclude(u => u.Movie).SingleOrDefaultAsync(u => u.UserName == username);
            return user;
        }

        public async Task ChangeVisibility(MyProfileUpdateVM vm)
        {
            var user = await GetCurrentUserAsync();
            user.IsPublic = vm.IsPublic;
            await _context.SaveChangesAsync();
        }

        public async Task ChangeProfileImage(MyProfileUpdateVM vm, string rootPath)
        {
            var user = await GetCurrentUserAsync();
            if (vm.ProfileImageFile != null)
            {
                user.ProfileImageUrl = await vm.ProfileImageFile.SaveAndProvideNameAsync(rootPath);
            }
            else
            {
                user.ProfileImageUrl = null;
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProfileImage()
        {
            var user = await GetCurrentUserAsync();
            user.ProfileImageUrl = null;
            await _context.SaveChangesAsync();
        }

        public IEnumerable<UserListItemVM> AdminGetAll()
        {
            var users = _context.Users.Include(u => u.Reviews).Include(u => u.Comments).Include(u => u.Posts).Include(u => u.WatchList).ThenInclude(u => u.WatchListMovies).ThenInclude(u => u.Movie).ToList();
            var vms = _mapper.Map<IEnumerable<UserListItemVM>>(users);
            return vms;
        }
    }
}
