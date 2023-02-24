using Assesment.Infrastructure.DbContexts;
using Assesment.Infrastructure.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Assesment.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(IApplicationDbContext context) : base((DbContext)context)
        {

        }

        //This method brings all the data from database using Stored Procedure
        public async Task<IEnumerable<Book>> GetBooksWithAuthorsAsync(string connectionString, string storedProcedureName)
        {
            var books = new List<Book>();
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
                            var book = new Book();
                            book.Id = reader.GetInt32(0);
                            book.Title = reader.GetString(1);
                            book.AuthorId = reader.GetInt32(2);
                            book.Author = new Author();
                            book.Author.Id=reader.GetInt32(2);
                            book.Author.Name = reader.GetString(3);
                            books.Add(book);
                        }
                    }
                }
            }
            return books;
        }
    }
}