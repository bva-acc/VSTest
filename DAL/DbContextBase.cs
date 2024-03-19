using Microsoft.EntityFrameworkCore;
using VSTest.DAL.Interfaces;

namespace VSTest.DAL;

public abstract class DbContextBase : DbContext, IUnitOfWork
{
    public abstract Task SaveAsync(CancellationToken cancellationToken = default);
}