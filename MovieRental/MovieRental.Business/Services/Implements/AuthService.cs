using Microsoft.AspNetCore.Identity;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AuthVMs;
using MovieRental.Core.Enums;
using MovieRental.Core.Models;
using System.Data;

namespace MovieRental.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<AppUser> _userManager { get; }
        SignInManager<AppUser> _signInManager { get; }
        RoleManager<IdentityRole> _roleManager { get; }

        public AuthService(RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> CreateInits()
        {
            foreach (var item in Enum.GetNames(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(item))
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = item,
                    });
                }
            }
            AppUser user = new AppUser
            {
                Email = "admin@gmail.com",
                UserName = "admin123",
                Name = "Admin",
                Surname = "Admin"
            };
            await _userManager.CreateAsync(user, "Admin123");
            AppUser user2 = await _userManager.FindByNameAsync("admin123");
            await _userManager.AddToRoleAsync(user2, Roles.Admin.ToString());
            return true;
        }

        public async Task<SignInResult> Login(LoginVM vm)
        {
            AppUser user;
            if (vm.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);
            }
            SignInResult result = new SignInResult();
            if (user != null)
            {
                result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, false);
                return result;
            }
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterVM vm)
        {
            AppUser user = new AppUser
            {
                Email = vm.Email,
                UserName = vm.Username,
                Name = vm.Name,
                Surname = vm.Surname,
            };
            var result = await _userManager.CreateAsync(user, vm.Password);
            //await _userManager.AddToRoleAsync(user, Roles.Member.ToString());
            return result;
        }
    }
}
