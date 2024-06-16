namespace Frontend.EntityDtos.Institution;

public class BaseInstitutionDto
{
    public Guid Id { get;  set; }

    public string Name { get;  set; }

    public string Address { get;  set; }

    public BaseInstitutionDto(Guid id, string name, string address)
    {
        Id = id;
        Name = name;
        Address = address;
    }
}