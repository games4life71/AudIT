using AudIT.Applicationa.Requests.Document.TemplateDocument.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.TemplateDocument.Commands.Create;

public class CreateTemplateDocCommand : IRequest<BaseDTOResponse<BaseTemplateDocDto>>
{
    public string? Name { get; set; }

    public string? Extension { get; set; }

    public Guid OwnerId { get; set; }

    public string? Version { get; set; }

    public DocumentState State { get; set; }

    public TemplateTypeStage Type { get; set; }

    public CreateTemplateDocCommand()
    {

    }
    public CreateTemplateDocCommand(string name, string extension, Guid ownerId, string version, DocumentState state,
        TemplateTypeStage type)
    {
        Name = name;
        Extension = extension;
        OwnerId = ownerId;
        Version = version;
        State = state;
        Type = type;
    }
}