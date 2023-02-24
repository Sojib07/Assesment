using Assesment.Infrastructure.Entities;

namespace Assesment.Infrastructure.Repositories
{
    public interface IBookRepository : IRepository<Book, int>
    {
        Task<IEnumerable<Book>> GetBooksWithAuthorsAsync(string connectionString, string storedProcedureName);
    }
}