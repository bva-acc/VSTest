using AutoMapper;
using VSTest.BLL.DTOs;
using VSTest.DAL.Entities;

namespace VSTest.BLL;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerData, Customer>();
        CreateMap<Customer, CustomerDetails>()
            .ForMember(x => x.FullName, x => x.MapFrom(x => string.IsNullOrEmpty(x.Patronymic)
                ? $"{x.Surname} {x.Name}" : $"{x.Surname} {x.Name} {x.Patronymic}"))
            .ForMember(x => x.Birthday, x => x.MapFrom(x => x.Birthday.ToString("dd.MM.yyyy")));
    }
}
