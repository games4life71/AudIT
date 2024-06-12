using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;
/// <summary>
/// This is a standalone document that is not associated with any other entity in the system
/// </summary>
public class StandaloneDocument:BaseDocument
{

    public Department Department { get; private set; }

    public Guid DepartmentId { get; private set; }

    private StandaloneDocument()
    {

    }

    private StandaloneDocument(
        string name,
        string extension,
        User owner,
        Guid ownerId,
        Department department,
        Guid departmentId,
        DocumentType type = DocumentType.Standalone
    ) : base(name, extension,type, owner, ownerId)
    {
        Department = department;
        DepartmentId = departmentId;
    }


    public static Result<StandaloneDocument> Create(
        string name,
        string extension,
        User owner,
        Guid ownerId,
        Department department,
        Guid departmentId
    )
    {
        //TODO : Add validation logic here

        return Result<StandaloneDocument>.Success(new StandaloneDocument(name, extension, owner, ownerId, department, departmentId));
    }


}