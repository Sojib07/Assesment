using Assesment.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Infrastructure.Repositories
{
    public interface IBookRepository : IRepository<Book, int>
    {
        Task<IEnumerable<Book>> GetBooksWithAuthorsAsync(string connectionString, string storedProcedureName);
    }
}