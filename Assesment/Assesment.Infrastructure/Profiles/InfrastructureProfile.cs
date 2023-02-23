using AutoMapper;
using AuthorBO = Assesment.Infrastructure.BusinessObjects.Author;
using AuthorEO = Assesment.Infrastructure.Entities.Author;
using BookBO = Assesment.Infrastructure.BusinessObjects.Book;
using BookEO = Assesment.Infrastructure.Entities.Book;

namespace Assesment.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<AuthorEO, AuthorBO>()
                .ReverseMap();

            CreateMap<BookEO, BookBO>()
                .ReverseMap();
        }
    }
}
