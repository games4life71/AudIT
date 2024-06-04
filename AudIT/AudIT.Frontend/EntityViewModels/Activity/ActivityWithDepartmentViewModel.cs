using Frontend.EntityDtos.Department;

namespace Frontend.EntityViewModels.Activity;

public class ActivityWithDepartmentViewModel
{
    public Guid Id { get;  set; }

    public string Name { get;  set; }

    public ActivityType Type { get;  set; }

    public Guid DepartmentId { get; set; }

    public Guid? ObjectiveActionId { get; set; }
    public string UserId { get;  set; }

    public string Department { get;  set; }

    public ActivityWithDepartmentViewModel(
        Guid id,
        string name,
        ActivityType type,
        Guid departmentId,
        Guid? objectiveActionId,
        string userId,
        string department)
    {
        Id = id;
        Name = name;
        Type = type;
        DepartmentId = departmentId;
        ObjectiveActionId = objectiveActionId;
        UserId = userId;
        Department = department;
    }


}