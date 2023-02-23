using Assesment.Infrastructure.DbContexts;
using Assesment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IAuthorRepository Authors { get; private set; }
        public IBookRepository Books { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            IAuthorRepository authorRepository,IBookRepository bookRepository) : base((DbContext)dbContext)
        {
            Authors = authorRepository;
            Books= bookRepository;
        }
    }
}