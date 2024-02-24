using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;



/// <summary>
/// This class models the relationship of many-to-many between the Audit and BaseDocument entities.
/// </summary>
public class AuditMissionDocument
{
    public Guid Id { get; set; }

    public AuditMission AuditMission { get; set; }

    public Guid AuditMissionId { get; set; }

    public BaseDocument BaseDocument { get; set; }

    public Guid BaseDocumentId { get; set; }

    public AuditMissionDocument()
    {
    }

    private AuditMissionDocument(AuditMission auditMission, BaseDocument baseDocument)
    {
        AuditMission = auditMission;
        BaseDocument = baseDocument;
    }

    public static Result<AuditMissionDocument> Create(AuditMission auditMission, BaseDocument baseDocument)
    {
        //TODO : Add validation logic here
        return Result<AuditMissionDocument>.Success(new AuditMissionDocument(auditMission, baseDocument));
    }

}