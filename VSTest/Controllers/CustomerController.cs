using Microsoft.AspNetCore.Mvc;
using VSTest.BLL.DTOs;
using VSTest.BLL.Intefaces;

namespace VSTest.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerBLL _service;

    public CustomerController(ICustomerBLL service)
    {
        _service = service;
    }

    /// <summary>
    /// Метод получает всех покупателей
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns> список с данными покупателей </returns>
    [HttpGet]
    public async Task<CustomerDetails[]> GetAllAsync(CancellationToken cancellationToken)
        => await _service.GetEntitesAsync(cancellationToken);

    /// <summary>
    /// Метод получает покупателя по идентификатору
    /// </summary>
    /// <param name="id">идентификатор покупателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns> данные покупателя </returns>
    [HttpGet("{id}")]
    public async Task<CustomerDetails> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await _service.GetEntityByIDAsync(id, cancellationToken);

    /// <summary>
    /// Метод создает покупателя
    /// </summary>
    /// <param name="data">модель покупателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns> идентификатор созданного покупателя </returns>
    [HttpPost]
    public async Task<Guid> CreateAsync(CustomerData data, CancellationToken cancellationToken = default)
        => await _service.CreateEntityAsync(data, cancellationToken);

    /// <summary>
    /// Метод изменяет данные покупателя
    /// </summary>
    /// <param name="id">идентификатор покупателя</param>
    /// <param name="data">модель покупателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns> результат операции </returns>
    [HttpPut("{id}")]
    public async Task UpdateAsync(Guid id, CustomerData data, CancellationToken cancellationToken = default)
        => await _service.UpdateEntityAsync(id, data, cancellationToken);

    /// <summary>
    /// Метод удаляет покупателя
    /// </summary>
    /// <param name="id">идентификатор покупателя</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns> результат операции </returns>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        => await _service.DeleteEntityAsync(id, cancellationToken);

}
