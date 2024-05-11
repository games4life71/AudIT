namespace AudIT.Applicationa.Requests.Document.Dto;

/// <summary>
/// This class models the base document data transfer object. It is used to transfer document data between the application layer and the presentation layer.
/// </summary>
public class BaseDocumentDto
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Extension { get; private set; }

    public string OwnerId { get; private set; }


    public BaseDocumentDto(Guid id, string name, string extension, string ownerId)
    {
        Id = id;
        Name = name;
        Extension = extension;
        OwnerId = ownerId;
    }
}