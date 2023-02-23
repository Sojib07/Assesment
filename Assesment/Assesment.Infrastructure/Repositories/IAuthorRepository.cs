using Assesment.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Infrastructure.Repositories
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
        Task<IEnumerable<Author>> GetAuthorsAsync(string connectionString, string storedProcedureName);
    }
}