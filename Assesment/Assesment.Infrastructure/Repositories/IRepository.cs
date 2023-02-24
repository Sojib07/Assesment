using Assesment.Infrastructure.Entities;

namespace Assesment.Infrastructure.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        IList<TEntity> GetAll(string includeProperties = "");
    }
}