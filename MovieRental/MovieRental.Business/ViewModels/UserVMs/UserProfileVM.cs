using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.UserVMs
{
    public class UserProfileVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Posts { get; set; }
        public WatchList WatchList { get; set; }
        public bool IsPublic { get; set; }

    }
}
