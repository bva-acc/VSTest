using System.Linq.Expressions;

namespace VSTest.DAL.Interfaces;

public interface IExecutableQuery<T> : IQueryable<T>
{
    Task<T[]> ExecuteAsync(CancellationToken cancellationToken);
    IExecutableQuery<T> Where(Expression<Func<T, bool>> predicate);
}
