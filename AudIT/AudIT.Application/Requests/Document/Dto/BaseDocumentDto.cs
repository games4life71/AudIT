using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Requests.Document.Dto;

/// <summary>
/// This class models the base document data transfer object. It is used to transfer document data between the application layer and the presentation layer.
/// </summary>
public class BaseDocumentDto
{
    public Guid Id { get;  set; }

    public string Name { get;  set; }

    public string Extension { get;  set; }

    public string OwnerId { get;  set; }

    public DocumentType DocumentType { get;  set; }

    public BaseDocumentDto(Guid id, string name, string extension, string ownerId, DocumentType documentType)
    {
        Id = id;
        Name = name;
        Extension = extension;
        OwnerId = ownerId;
        DocumentType = documentType;
    }

}