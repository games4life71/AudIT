using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.Document.TemplateDocument.DTO;

public class BaseTemplateDocDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Extension { get; set; }

    public Guid OwnerId { get; set; }

    public TemplateTypeStage Type { get; set; }

    public DocumentState State { get; set; }

    public int Version { get; set; }

    public BaseTemplateDocDto(Guid id, string name, string extension, Guid ownerId, TemplateTypeStage type,
        DocumentState state, int version)
    {
        Id = id;
        Name = name;
        Extension = extension;
        OwnerId = ownerId;
        Type = type;
        State = state;
        Version = version;
    }
}