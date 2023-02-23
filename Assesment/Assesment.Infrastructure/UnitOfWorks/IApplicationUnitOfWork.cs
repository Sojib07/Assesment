using Assesment.Infrastructure.Repositories;

namespace Assesment.Infrastructure.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
    }
}