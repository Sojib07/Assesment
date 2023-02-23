using Assesment.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
    }
}