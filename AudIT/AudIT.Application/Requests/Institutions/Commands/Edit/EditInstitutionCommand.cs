using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Commands.Edit;

public class EditInstitutionCommand:IRequest<BaseDTOResponse<InstitutionInfoDto>>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public EditInstitutionCommand(Guid id, string name, string address, string phoneNumber)
    {
        Id = id;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}