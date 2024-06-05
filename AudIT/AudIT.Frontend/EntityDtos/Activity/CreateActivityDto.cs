using Frontend.EntityViewModels.Activity;

namespace Frontend.EntityDtos.Activity;

public class CreateActivityDto
{
    public string Name { get; set; }

    public ActivityType Type { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid AuditMissionId { get; set; }

    public Guid UserId { get; set; }

    public Guid? ObjectiveActionId { get; set; }

    public CreateActivityDto(string name, ActivityType type, Guid departmentId, Guid auditMissionId, Guid userId,
        Guid? objectiveActionId)
    {
        Name = name;
        Type = type;
        DepartmentId = departmentId;
        AuditMissionId = auditMissionId;
        UserId = userId;
        ObjectiveActionId = objectiveActionId;
    }

    public CreateActivityDto()
    {

    }
}