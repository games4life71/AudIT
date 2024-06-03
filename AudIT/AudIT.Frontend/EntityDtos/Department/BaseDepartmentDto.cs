using Frontend.EntityDtos.Institution;

namespace Frontend.EntityDtos.Department;

public class BaseDepartmentDto
{
    public Guid Id { get; private set; }

    public string? Name { get; private set; }

    public string Address { get; private set; }

    public string HomePhoneNumber { get; private set; }

    public BaseInstitutionDto Institution { get; private set; }


    public BaseDepartmentDto(Guid id, string? name, string address, string homePhoneNumber,
        BaseInstitutionDto institution)
    {
        Id = id;
        Name = name;
        Address = address;
        HomePhoneNumber = homePhoneNumber;
        Institution = institution;
    }
}