using AutoMapper;
using Assesment.API.Models;
using Assesment.Infrastructure.BusinessObjects;

namespace Assesment.API.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            //CreateMap<BookModel, Course>()
            //    .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Title))
            //    .ReverseMap();
        }
    }
}
