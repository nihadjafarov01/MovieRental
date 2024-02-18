using AutoMapper;
using MovieRental.Business.Repositories.Interfaces;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.CommentVMs;
using MovieRental.Business.ViewModels.CommentVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Services.Implements
{
    public class CommentService : ICommentService
    {
        readonly ICommentRepository _commentRepository;
        readonly IMapper _mapper;
        readonly IUserService _userService;
        public CommentService(ICommentRepository commentRepository, IMapper mapper, IUserService userService)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public IEnumerable<AdminCommentListItemVM> AdminGetAll()
        {
            var models = _commentRepository.GetAll(true, "User");
            var vms = _mapper.Map<IEnumerable<AdminCommentListItemVM>>(models);
            return vms;
        }

        public async Task CreateAsync(CommentCreateVM vm)
        {
            vm.UserId = await _userService.GetUserIdAsync();
            var model = _mapper.Map<Comment>(vm);
            await _commentRepository.CreateAsync(model);
            await _commentRepository.SaveAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentListItemVM> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CommentListItemVM> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CommentUpdateVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
