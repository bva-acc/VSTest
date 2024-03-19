namespace VSTest.DAL.Entities;

public class Customer
{
    public Guid ID { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string? Patronymic { get; init; }
    public DateTime Birthday { get; init; }
    public string PhoneNumber { get; init; }
}
