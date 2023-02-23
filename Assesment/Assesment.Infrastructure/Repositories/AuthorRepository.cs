using Assesment.Infrastructure.DbContexts;
using Assesment.Infrastructure.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Assesment.Infrastructure.Repositories
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(IApplicationDbContext context) : base((DbContext)context)
        {

        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync(string connectionString, string storedProcedureName)
        {
            var authors = new List<Author>();
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var author = new Author();
                            author.Id = reader.GetInt32(0);
                            author.Name = reader.GetString(1);
                            authors.Add(author);
                        }
                    }
                }
            }
            return authors;
        }
    }
}