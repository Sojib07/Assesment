using Assesment.Infrastructure.UnitOfWorks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using BookBO = Assesment.Infrastructure.BusinessObjects.Book;
using BookEO = Assesment.Infrastructure.Entities.Book;

namespace Assesment.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;
        private readonly string _connectionString;

        public BookService(IMapper mapper, IApplicationUnitOfWork applicationUnitOfWork, IConfiguration configuration)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IList<BookBO>> GetAllBooks()
        {
            IList<BookEO> books= _applicationUnitOfWork.Books.GetAll("Author");
            IList<BookBO> booksBO=new List<BookBO>();
            foreach(BookEO book in books)
            {
                var bookBO = _mapper.Map<BookBO>(book);
                booksBO.Add(bookBO);
            }

            return booksBO;
        }

        public async Task<IList<BookBO>> GetAllBooksWithStoredProcedure()
        {
            var booksEO = await _applicationUnitOfWork.Books.GetBooksWithAuthorsAsync(_connectionString, "GetBooksWithAuthors");
            var booksBO = new List<BookBO>();
            foreach(var book in booksEO)
            {
                var bookBO=_mapper.Map<BookBO>(book);
                booksBO.Add(bookBO);
            }
            return booksBO;
        }
    }
}