using Frontend.EntityDtos.Institution;

namespace Frontend.EntityDtos.Department;

public class BaseDepartmentDto
{
    public Guid Id { get;  set; }

    public string? Name { get;  set; }

    public string Address { get;  set; }

    public string HomePhoneNumber { get;  set; }

    public BaseInstitutionDto Institution { get;  set; }


    public BaseDepartmentDto(Guid id, string? name, string address, string homePhoneNumber,
        BaseInstitutionDto institution)
    {
        Id = id;
        Name = name;
        Address = address;
        HomePhoneNumber = homePhoneNumber;
        Institution = institution;
    }

    public BaseDepartmentDto()
    {

    }
}