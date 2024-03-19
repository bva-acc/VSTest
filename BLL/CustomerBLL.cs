using AutoMapper;
using VSTest.BLL.DTOs;
using VSTest.BLL.Intefaces;
using VSTest.Core;
using VSTest.DAL.Entities;
using VSTest.DAL.Interfaces;

namespace VSTest.BLL;

public class CustomerBLL : ICustomerBLL, ISelfRegisteredService<ICustomerBLL>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Customer> _repository;
    private readonly IReadonlyRepository<Customer> _readonlyRepository;
    private readonly IUnitOfWork _saveChangesCommand;

    public CustomerBLL(
        IMapper mapper,
        IRepository<Customer> repository,
        IReadonlyRepository<Customer> readonlyRepository,
        IUnitOfWork saveChangesCommand
        )
    {
        _mapper = mapper;
        _repository = repository;
        _readonlyRepository = readonlyRepository;
        _saveChangesCommand = saveChangesCommand;
    }

    public async Task<Guid> CreateEntityAsync(CustomerData data, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Customer>(data);
        _repository.Insert(entity);

        await _saveChangesCommand.SaveAsync(cancellationToken);

        return entity.ID;
    }

    public async Task DeleteEntityAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.FirstOrDefaultAsync(x => x.ID == id, cancellationToken)
            ?? throw new Exception($"Не найден объект с ID {id}");

        _repository.Delete(entity);
        await _saveChangesCommand.SaveAsync(cancellationToken);
    }

    public async Task<CustomerDetails[]> GetEntitesAsync(CancellationToken cancellationToken)
    {
        var entities = await _readonlyRepository.ToArrayAsync(cancellationToken)
            ?? throw new Exception($"Не найдено ни одного объекта");

        return _mapper.Map<CustomerDetails[]>(entities);
    }

    public async Task<CustomerDetails> GetEntityByIDAsync(Guid? id, CancellationToken cancellationToken)
    {
        var entity = await _readonlyRepository.FirstOrDefaultAsync(x => x.ID == id, cancellationToken)
            ?? throw new Exception($"Не найден объект с ID {id}");

        return _mapper.Map<CustomerDetails>(entity);
    }

    public async Task UpdateEntityAsync(Guid id, CustomerData data, CancellationToken cancellationToken)
    {
        var entity = await _readonlyRepository.FirstOrDefaultAsync(x => x.ID == id, cancellationToken)
            ?? throw new Exception($"Не найден объект с ID {id}");

        _mapper.Map(data, entity);

        await _saveChangesCommand.SaveAsync(cancellationToken);
    }
}
