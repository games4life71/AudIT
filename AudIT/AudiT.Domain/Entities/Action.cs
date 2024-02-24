using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;



/// <summary>
/// This class models the atomic operations of a mission : activity
/// </summary>
public class Action:AuditableEntity
{

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ActivityType Type { get; private set; }

    public Department Department { get; private set; }

    public Guid DepartmentId { get; private set; }

    //the user who created the activity
    public User User { get; private set; }

    public string  UserId { get; private set; }


    public Action()
    {

    }


    private Action(
        string name,
        ActivityType type,
        Department department,
        Guid departmentId,
        User user,
        Guid userId
    )
    {
        Name = name;
        Type = type;
        Department = department;
        DepartmentId = departmentId;
        User = user;
        UserId = userId.ToString();
    }

    public static Result<Action> Create(string name, ActivityType type, Department department, Guid departmentId, User user, Guid userId)
    {
        //TODO : Add validation logic here

        return Result<Action>.Success(new Action(name, type, department, departmentId, user, userId));
    }

}


public enum ActivityType
{
    //the activity is a mission
    Mission,
    //the activity is a task
    Task
}
