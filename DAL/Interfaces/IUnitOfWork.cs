namespace VSTest.DAL.Interfaces;

public interface IUnitOfWork
{
    /// <summary>
    /// Сохранить изменения асинхронно
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task SaveAsync(CancellationToken cancellationToken = default);
}