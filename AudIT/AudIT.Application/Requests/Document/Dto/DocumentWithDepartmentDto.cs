namespace AudIT.Applicationa.Requests.Document.Dto;

public class DocumentWithDepartmentDto
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Extension { get; private set; }

    public string OwnerId { get; private set; }

    public Guid DepartmentId { get; set; }

    // public DocumentWithDepartmentDto(BaseDocumentDto baseDocument, Guid departmentId)
    // {
    //     BaseDocument = baseDocument;
    //     DepartmentId = departmentId;
    // }

    public DocumentWithDepartmentDto(Guid id, string name, string extension, string ownerId, Guid departmentId)
    {
        Id = id;
        Name = name;
        Extension = extension;
        OwnerId = ownerId;
        DepartmentId = departmentId;
    }
}