using AudIT.Applicationa.Requests.Department.Dto;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class DepartmentProfile : MyCustomProfile
{
    public DepartmentProfile()
    {
        CreateMap<Department, BaseDepartmentDto>();
    }
}