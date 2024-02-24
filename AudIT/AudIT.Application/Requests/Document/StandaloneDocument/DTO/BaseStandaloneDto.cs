namespace AudIT.Applicationa.Requests.Document.StandaloneDocument.DTO;

/// <summary>
/// This class models the basic response of an enpoint that returns a standalone document
///
/// </summary>
public class BaseStandaloneDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Extension { get; set; }

    public Guid OwnerId { get; set; }

    public Guid DepartmentId { get; set; }

    public BaseStandaloneDto(Guid id, string name, string extension, Guid ownerId, Guid departmentId)
    {
        Id = id;
        Name = name;
        Extension = extension;
        OwnerId = ownerId;
        DepartmentId = departmentId;
    }
}