using VSTest.BLL.DTOs;

namespace VSTest.BLL.Intefaces;

/// <summary>
/// Интерфейс для сущности Покупатель
/// </summary>
public interface ICustomerBLL
{
    /// <summary>
    /// Метод получает всеx покупателей
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>список с данными покупателей</returns>
    Task<CustomerDetails[]> GetEntitesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Метод получает покупателя по идентификатору
    /// </summary>
    /// <param name="id">идентификатор покупателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>данные покупателя</returns>
    Task<CustomerDetails> GetEntityByIDAsync(Guid? id, CancellationToken cancellationToken);

    /// <summary>
    /// Метод создает покупателя
    /// </summary>
    /// <param name="data">модель покупателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>идентификатор покупателя</returns>
    Task<Guid> CreateEntityAsync(CustomerData data, CancellationToken cancellationToken);

    /// <summary>
    /// Метод обновляет покупателя
    /// </summary>
    /// <param name="id">идентификатор покупателя</param>
    /// <param name="data">модель покупателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    Task UpdateEntityAsync(Guid id, CustomerData data, CancellationToken cancellationToken);

    /// <summary>
    /// Метод удаляет покупателя
    /// </summary>
    /// <param name="id">идентификатор покупателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    Task DeleteEntityAsync(Guid id, CancellationToken cancellationToken);
}
