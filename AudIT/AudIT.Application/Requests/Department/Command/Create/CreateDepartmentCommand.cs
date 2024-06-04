using System.ComponentModel.DataAnnotations;
using AudIT.Applicationa.Requests.Department.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Department.Command.Create;

public class CreateDepartmentCommand : IRequest<BaseDTOResponse<BaseDepartmentDto>>
{
    public Guid InstitutionId { get; set; }

    public string Name { get; set; }

    public string Adress { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    public CreateDepartmentCommand(Guid institutionId, string name, string adress, string phoneNumber)
    {
        InstitutionId = institutionId;
        Name = name;
        Adress = adress;
        PhoneNumber = phoneNumber;
    }
}