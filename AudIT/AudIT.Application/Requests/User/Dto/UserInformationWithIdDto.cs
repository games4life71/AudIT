namespace AudIT.Applicationa.Requests.User.Dto;

public class UserInformationWithIdDto
{
    public string FirstEmail { get; set; }

    public string? SecondEmail { get;   set;}

    public string Adress { get; set; }

    public string? PhoneNumber { get; set;}

    public string? OfficePhoneNumber { get; set; }

    public string? Functie { get; set; }

    public string? Username { get; set; }

    public Guid Id { get; set; }


}