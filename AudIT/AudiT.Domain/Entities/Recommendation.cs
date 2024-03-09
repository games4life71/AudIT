using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

/// <summary>
/// This class models the recommendation of an audit mission
///
/// </summary>
public class Recommendation : AuditableEntity
{
    public Guid Id { get; private set; }

    public string Description { get; private set; }

    public Status Status { get; private set; }

    public DateTime DueDate { get; private set; }

    public ObjectiveAction ObjectiveAction { get; private set; }
    public Guid ObjectiveActionId { get; private set; }

    private Recommendation(string description, DateTime dueDate, Guid objectiveActionId,ObjectiveAction objectiveAction)
    {
        Description = description;
        Status = Status.NotImplemented;
        DueDate = dueDate;
        ObjectiveAction = objectiveAction;
        ObjectiveActionId = objectiveActionId;
    }


    public Recommendation()
    {

    }
    public static Result<Recommendation> Create(string description, DateTime dueDate, Guid objectiveActionId, ObjectiveAction objectiveAction)
    {
        //TODO : Add validation logic here
        return Result<Recommendation>.Success(new Recommendation(description, dueDate, objectiveActionId, objectiveAction));
    }
}

public enum Status
{
    Implemented,
    PartiallyImplemented,
    NotImplemented,
}