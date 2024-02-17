using Microsoft.AspNetCore.Http;

namespace MovieRental.Business.ViewModels.UserVMs
{
    public class MyProfileUpdateVM
    {
        public IFormFile? ProfileImageFile { get; set; }
        public bool IsPublic { get; set; }
    }
}
