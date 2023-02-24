using Assesment.Infrastructure.Entities;

namespace Assesment.Infrastructure.Repositories
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
        Task<IEnumerable<Author>> GetAuthorsAsync(string connectionString, string storedProcedureName);
    }
}