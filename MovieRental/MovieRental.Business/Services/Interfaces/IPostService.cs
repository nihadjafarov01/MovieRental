﻿using MovieRental.Business.ViewModels.AdminVMs.PostVMs;
using MovieRental.Business.ViewModels.PostVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IPostService
    {
        public IEnumerable<PostListItemVM> GetAll();
        public IEnumerable<AdminPostListItemVM> AdminGetAll();
        public Task CreateAsync(PostCreateVM vm);
        public Task<PostVM> GetVmByIdAsync(int postId);
    }
    
}
