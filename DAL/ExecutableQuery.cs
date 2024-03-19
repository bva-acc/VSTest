using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using VSTest.DAL.Interfaces;

namespace VSTest.DAL;

internal class ExecutableQuery<T> : IExecutableQuery<T>, IAsyncEnumerable<T>
{
    private IQueryable<T> _query;

    public ExecutableQuery(IQueryable<T> query)
    {
        _query = query;
    }

    #region IExecutableQuery<T>

    public Type ElementType => _query.ElementType;

    public Expression Expression => _query.Expression;

    public IQueryProvider Provider => _query.Provider;

    public Task<T[]> ExecuteAsync(CancellationToken cancellationToken)
    {
        return _query.ToArrayAsync(cancellationToken);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _query.GetEnumerator();
    }

    public IExecutableQuery<T> Where(Expression<Func<T, bool>> predicate)
    {
        _query = _query.Where(predicate);
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _query.GetEnumerator();
    }

    #endregion

    #region IAsyncEnumerable<T>

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return _query.AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);
    }

    #endregion
}