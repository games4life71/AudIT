namespace Frontend.EntityDtos.Institution;

public class CreateInstitutionDto
{
    public string Name { get; set; }

    public string Address { get; set; }

    public string HomePhoneNumber { get; set; }

    public CreateInstitutionDto(string name, string address, string homePhoneNumber)
    {
        Name = name;
        Address = address;
        HomePhoneNumber = homePhoneNumber;
    }

    public CreateInstitutionDto()
    {

    }
}