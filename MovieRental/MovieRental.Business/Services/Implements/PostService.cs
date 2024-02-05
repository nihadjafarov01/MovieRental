using AutoMapper;
using MovieRental.Business.Repositories.Interfaces;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.PostVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Services.Implements
{
    public class PostService : IPostService
    {
        readonly IPostRepository _repository;
        readonly IMapper _mapper;
        readonly IUserService _userService;

        public PostService(IMapper mapper, IPostRepository repository, IUserService userService)
        {
            _mapper = mapper;
            _repository = repository;
            _userService = userService;
        }

        public async Task CreateAsync(PostCreateVM vm)
        {
            vm.UserId = await _userService.GetUserIdAsync();
            var model = _mapper.Map<Post>(vm);
            await _repository.CreateAsync(model);
            await _repository.SaveAsync();
        }

        public IEnumerable<PostListItemVM> GetAll()
        {
            var data = _repository.GetAll(false, "Tag", "Movie", "User");
            var rdata = _mapper.Map<IEnumerable<PostListItemVM>>(data);
            return rdata;
        }
    }
}
