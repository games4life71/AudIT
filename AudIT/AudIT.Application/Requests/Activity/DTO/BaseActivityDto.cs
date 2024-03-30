using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.Activity.DTO;

public class BaseActivityDto
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ActivityType Type { get; private set; }

    public Guid DepartmentId { get; private set; }


    public Guid? ObjectiveActionId { get; private set; }
    public string UserId { get; private set; }
    //the user who created the activity

    public BaseActivityDto(Guid id, string name, ActivityType type, Guid departmentId, string userId,
        Guid? objectiveActionId = null)
    {
        Id = id;
        Name = name;
        Type = type;
        DepartmentId = departmentId;
        UserId = userId;
        ObjectiveActionId = objectiveActionId;
    }
}