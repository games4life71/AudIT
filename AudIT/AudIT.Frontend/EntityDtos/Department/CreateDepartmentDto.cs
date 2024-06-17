namespace Frontend.EntityDtos.Department;

public class CreateDepartmentDto
{
    public Guid InstitutionId { get; set; }

    public string Name { get; set; }

    public string Adress { get; set; }

    public string PhoneNumber { get; set; }

    public CreateDepartmentDto(Guid institutionId, string name, string adress, string phoneNumber)
    {
        InstitutionId = institutionId;
        Name = name;
        Adress = adress;
        PhoneNumber = phoneNumber;
    }

    public CreateDepartmentDto()
    {
    }
}