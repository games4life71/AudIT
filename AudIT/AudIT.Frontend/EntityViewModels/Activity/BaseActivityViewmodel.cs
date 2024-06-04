namespace Frontend.EntityViewModels.Activity;

public class BaseActivityViewmodel
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ActivityType Type { get; private set; }

    public Guid DepartmentId { get; private set; }


    public Guid? ObjectiveActionId { get; private set; }
    public string UserId { get; private set; }
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