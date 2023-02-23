using Assesment.Infrastructure.BusinessObjects;

namespace Assesment.Infrastructure.Services
{
    public interface IBookService
    {
        Task<IList<Book>> GetAllBooks();
        Task<IList<Book>> GetAllBooksWithStoredProcedure();
    }
}