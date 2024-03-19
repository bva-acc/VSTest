namespace VSTest.BLL.DTOs;

public class CustomerDetails
{
    public Guid ID { get; set; }
    public string FullName { get; init; }
    public string Birthday { get; init; }
    public string PhoneNumber { get; init; }
}
