using AudIT.Applicationa.Requests.Document.StandaloneDocument.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Create;

public class CreateStandDocumentCommand : IRequest<BaseDTOResponse<BaseStandaloneDto>>
{
    public string? Name { get; set; }

    public string? Extension { get; set; }

    public  Guid OwnerId { get; set; }

    public Guid DepartmentId { get; set; }

    public CreateStandDocumentCommand(string name, string extension,  Guid departmentId)
    {
        Name = name;
        Extension = extension;
        DepartmentId = departmentId;
    }

    public CreateStandDocumentCommand()
    {

    }
}