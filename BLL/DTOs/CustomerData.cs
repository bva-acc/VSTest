namespace VSTest.BLL.DTOs;

public class CustomerData
{
    public string Name { get; init; }
    public string Surname { get; init; }
    public string? Patronymic { get; init; }
    public DateTime Birthday { get; init; }
    public string PhoneNumber { get; init; }
}
