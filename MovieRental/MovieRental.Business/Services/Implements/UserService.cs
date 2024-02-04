﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.UserVMs;
using MovieRental.Core.Models;
using System.Security.Claims;

namespace MovieRental.Business.Services.Implements
{
    public class UserService : IUserService
    {
        IMapper _mapper { get; }
        UserManager<AppUser> _userManager { get; }
        private readonly IHttpContextAccessor _httpContext;

        public UserService(UserManager<AppUser> userManager, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContext = httpContext;
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
            var user = await _userManager.FindByNameAsync(username);
            UserProfileVM vm = _mapper.Map<UserProfileVM>(user);
            return vm;
        }
    }
}
