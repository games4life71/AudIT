namespace AudIT.Applicationa.Requests.Institution.DTO;

public class BaseInstitutionDto
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Address { get; private set; }
}