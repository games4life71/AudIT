using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

/// <summary>
/// This class models the relationship of many-to-many between the Audit Mission and multiple objectives entities.
/// </summary>
public class AuditMissionObjectives
{
    public Guid Id { get; set; }

    public AuditMission AuditMission { get; set; }

    public Guid AuditMissionId { get; set; }

    public Objective Objective { get; set; }

    public Guid ObjectiveId { get; set; }


    public AuditMissionObjectives()
    {
    }

    private AuditMissionObjectives(AuditMission auditMission, Guid auditMissionId, Objective objective,
        Guid objectiveId)
    {
        Id = new Guid();
        AuditMission = auditMission;
        AuditMissionId = auditMissionId;
        Objective = objective;
        ObjectiveId = objectiveId;
    }


    public static Result<AuditMissionObjectives> Create(AuditMission auditMission, Objective objective)
    {
        //TODO : Add validation logic here
        return Result<AuditMissionObjectives>.Success(new AuditMissionObjectives(auditMission, auditMission.Id,
            objective, objective.Id));
    }
}