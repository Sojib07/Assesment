using Autofac;
using AutoMapper;
using Assesment.Infrastructure.BusinessObjects;
using Assesment.Infrastructure.Services;

namespace Assesment.API.Models
{
    public class AuthorModel
    {
        private IAuthorService? _authorService;
        private IMapper _mapper;

        public int Id { get; set; }
        public string Name { get; set; }

        public AuthorModel()
        {

        }

        public AuthorModel(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _authorService = scope.Resolve<IAuthorService>();
            _mapper = scope.Resolve<IMapper>();
        }

        internal async Task<IList<Author>> GetAuthors()
        {
            return await _authorService?.GetAllAuthors();
        }
    }
}