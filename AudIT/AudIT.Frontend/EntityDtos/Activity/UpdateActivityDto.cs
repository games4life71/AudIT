using Frontend.EntityViewModels.Activity;

namespace Frontend.EntityDtos.Activity;

public class UpdateActivityDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ActivityType Type { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid AuditMissionId { get; set; }


    public Guid? ObjectiveActionId { get; set; }

    public UpdateActivityDto(Guid id, string name, ActivityType type, Guid departmentId, Guid auditMissionId,
        Guid? objectiveActionId)
    {
        Id = id;
        Name = name;
        Type = type;
        DepartmentId = departmentId;
        AuditMissionId = auditMissionId;
        ObjectiveActionId = objectiveActionId;
    }
}