using VSTest.DAL.Interfaces;

namespace VSTest.DAL;

public class Repository<TEntity> :
        ReadonlyRepository<TEntity>,
        IRepository<TEntity>
        where TEntity : class
{
    public Repository(VSDbContext dbContext)
        : base(dbContext)
    {
    }

    public void Insert(TEntity entity)
        => Set.Add(entity);

    public void Delete(TEntity entity)
        => Set.Remove(entity);
}