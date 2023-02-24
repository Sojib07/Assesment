using Assesment.Infrastructure.BusinessObjects;
using Assesment.Infrastructure.Services;
using Autofac;
using AutoMapper;

namespace Assesment.Web.Models
{
    public class BookModel
    {
        private IBookService? _bookService;
        private IMapper _mapper;
        public string is_accepted { get; set; }
        public long score { get; set; }
        public int answer_id { get; set; }

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

        public async Task<IList<Book>> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }

        public async Task<IList<Book>> GetAllBooksWithStoredProcedure()
        {
            return await _bookService.GetAllBooksWithStoredProcedure();
        }
    }
}