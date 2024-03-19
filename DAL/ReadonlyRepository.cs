using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VSTest.DAL.Interfaces;

namespace VSTest.DAL;

public class ReadonlyRepository<TEntity> :
IReadonlyRepository<TEntity>
        where TEntity : class
{

    protected DbSet<TEntity> Set { get; }

    protected ReadonlyRepository(VSDbContext dbContext)
    {
        Set = dbContext.Set<TEntity>();
        Queryable = Set;
    }

    protected IQueryable<TEntity> Queryable { get; private set; }

    public Task<TEntity[]> ToArrayAsync(CancellationToken token = default)
        => Query().ToArrayAsync(token);

    public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default)
        => Query(predicate).FirstOrDefaultAsync(token);

    public virtual IExecutableQuery<TEntity> Query()
        => new ExecutableQuery<TEntity>(Queryable);

    public virtual IExecutableQuery<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        => new ExecutableQuery<TEntity>(Queryable.Where(predicate));
}