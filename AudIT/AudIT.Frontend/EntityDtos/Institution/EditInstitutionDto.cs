namespace Frontend.EntityDtos.Institution;

public class EditInstitutionDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public EditInstitutionDto(Guid id, string name, string address, string phoneNumber)
    {
        Id = id;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    public EditInstitutionDto()
    {

    }
}