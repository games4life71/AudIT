namespace Frontend.EntityViewModels.Activity;

public class BaseActivityViewmodel
{
    public Guid Id { get;  set; }

    public string Name { get;  set; }

    public ActivityType Type { get; set; }

    public Guid DepartmentId { get; set; }


    public Guid? ObjectiveActionId { get;  set; }
    public string UserId { get; set; }
    //the user who created the activity

    public BaseActivityViewmodel(Guid id, string name, ActivityType type, Guid departmentId, string userId,
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

public enum ActivityType
{
    //the activity is a mission
    Mission,
    //the activity is a task
    Task,
    ForObjectiveAction //the activity is binded to an objective action
}