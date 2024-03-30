using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;



/// <summary>
/// This class models the atomic operations of a mission : activity
/// </summary>
public class Activity:AuditableEntity
{

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ActivityType Type { get; private set; }

    public Department Department { get; private set; }

    public Guid DepartmentId { get; private set; }

    //the user who created the activity
    public User User { get; private set; }

    public string  UserId { get; private set; }


    public Guid? ObjectiveActionId { get; private set; }

    public Guid AuditMissionId { get; private set; }




    public List<BaseDocument> AttachedDocuments { get; private set; }

    public Activity()
    {

        Id = Guid.NewGuid();
        AuditMissionId = Guid.Empty;
        Name = string.Empty;
        Type = ActivityType.Task; // or ActivityType.Mission, depending on your default
        Department = null; // or a default Department instance
        DepartmentId = Guid.Empty;
        User = null; // or a default User instance
        UserId = string.Empty;
        AttachedDocuments = new List<BaseDocument>();
    }


    private Activity(
        string name,
        ActivityType type,
        Department department,
        Guid departmentId,
        User user,
        Guid userId,
        Guid auditMissionId,
        Guid? objectiveActionId = null
    )
    {
        Name = name;
        Type = type;
        Department = department;
        DepartmentId = departmentId;
        User = user;
        UserId = userId.ToString();
        AttachedDocuments = new List<BaseDocument>();
        AuditMissionId = auditMissionId;
        ObjectiveActionId = objectiveActionId;
    }

    public bool AddDocument(BaseDocument document)
    {
        //TODO : Add validation logic here
        if (AttachedDocuments.Any(d => d.Id == document.Id))
            return false;

        AttachedDocuments.Add(document);
        return true;
    }

    public static Result<Activity> Create(string name, ActivityType type, Department department, Guid departmentId, User user, Guid userId, Guid auditMissionId, Guid? objectiveActionId = null)
    {
        //TODO : Add validation logic here

        return Result<Activity>.Success(new Activity(name, type, department, departmentId, user, userId, auditMissionId, objectiveActionId));
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
