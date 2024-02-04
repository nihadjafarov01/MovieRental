using Microsoft.AspNetCore.Http;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.UserVMs;
using MovieRental.Core.Models;
using MovieRental.DAL.Contexts;

namespace MovieRental.Business.Services.Implements
{
    public class LayoutService : ILayoutService
    {
        readonly IUserService _userService;

        public LayoutService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserVM> GetUserAsync()
        {
            UserVM userVM = await _userService.GetUserVMAsync();
            return userVM;
        }
    }
}
