using System.ComponentModel.DataAnnotations;
using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Institution.Commands.Create;

public class CreateInstitutionCommand : IRequest<BaseDTOResponse<BaseInstitutionDto>>
{
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }


    [Phone]
    [Required]
    public string HomePhoneNumber { get; set; }

    public CreateInstitutionCommand(string name, string address,string homePhoneNumber)
    {
        Name = name;
        Address = address;
        this.HomePhoneNumber = homePhoneNumber;
    }

}