using System.Linq.Expressions;

namespace VSTest.DAL.Interfaces;

public interface IReadonlyRepository<TEntity>
        where TEntity : class
{
    Task<TEntity[]> ToArrayAsync(CancellationToken token = default);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default);
}