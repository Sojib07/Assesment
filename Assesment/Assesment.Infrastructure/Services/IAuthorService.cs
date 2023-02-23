using Assesment.Infrastructure.BusinessObjects;

namespace Assesment.Infrastructure.Services
{
    public interface IAuthorService
    {
        Task<IList<Author>> GetAllAuthors();
        Task<IList<Author>> GetAllAuthorsWithStoredProcedure();
    }
}