using AutoMapper;
using MovieRental.Business.Repositories.Interfaces;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.TagVMs;

namespace MovieRental.Business.Services.Implements
{
    public class TagService : ITagService
    {
        ITagRepository _repo { get; }
        IMapper _mapper { get; }

        public TagService(IMapper mapper, ITagRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public IEnumerable<TagListItemVM> GetAll()
        {
            var data = _repo.GetAll();
            var rdata = _mapper.Map<IEnumerable<TagListItemVM>>(data);
            return rdata;
        }
    }
}
