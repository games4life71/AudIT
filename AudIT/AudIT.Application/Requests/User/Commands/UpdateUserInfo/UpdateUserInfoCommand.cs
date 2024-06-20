using AudIT.Applicationa.Requests.User.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.User.Commands.UpdateUserInfo;

public class UpdateUserInfoCommand: IRequest<BaseDTOResponse<BaseUserInformationDto>>
{
    public string? Id { get; set; }

    public string? SecondEmail { get;   set;}

    public string Adress { get; set; }

    public string? PhoneNumber { get; set;}

    public string? OfficePhoneNumber { get; set; }

    public string? Functie { get; set; }

    public string? Username { get; set; }

    public UpdateUserInfoCommand(string id,  string? secondEmail, string adress, string? phoneNumber, string? officePhoneNumber, string? functie, string? username)
    {
        Id = id;

        SecondEmail = secondEmail;
        Adress = adress;
        PhoneNumber = phoneNumber;
        OfficePhoneNumber = officePhoneNumber;
        Functie = functie;
        Username = username;
    }
}