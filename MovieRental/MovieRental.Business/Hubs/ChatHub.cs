using Microsoft.AspNetCore.SignalR;
using MovieRental.Business.Services.Interfaces;

namespace MovieRental.Business.Hubs
{
    public class ChatHub : Hub
    {
        IUserService _userService;

        public ChatHub(IUserService userService)
        {
            _userService = userService;
        }

        public async Task SendMessage(string message)
        {
            var uservm = await _userService.GetUserVMAsync();
            await Clients.All.SendAsync("ReceiveMessage", uservm.Username, uservm.ProfileImageUrl, message);
        }
    }
}
