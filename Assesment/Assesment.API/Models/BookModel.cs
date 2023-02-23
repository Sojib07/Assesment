using Autofac;
using AutoMapper;
using Assesment.Infrastructure.BusinessObjects;
using Assesment.Infrastructure.Services;

namespace Assesment.API.Models
{
    public class BookModel
    {
        private IBookService? _bookService;
        private IMapper _mapper;

        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public BookModel()
        {

        }

        public BookModel(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _bookService = scope.Resolve<IBookService>();
            _mapper = scope.Resolve<IMapper>();
        }

        internal async Task<IList<Book>> GetBooks()
        {
            return await _bookService?.GetAllBooks();
        }
    }
}