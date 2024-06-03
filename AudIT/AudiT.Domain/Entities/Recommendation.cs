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

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string RecommendationDescription { get; set; }

    private Recommendation(
        string description,
        DateTime dueDate,
        string problem,
        string? aditionalFindings,
        string? cause,
        string? consequence,
        string recommendationDescription,
        ObjectiveAction objectiveAction,
        Guid objectiveActionId)
    {
        Description = description;
        DueDate = dueDate;
        Problem = problem;
        AditionalFindings = aditionalFindings;
        Cause = cause;
        Consequence = consequence;
        RecommendationDescription = recommendationDescription;
        ObjectiveAction = objectiveAction;
        ObjectiveActionId = objectiveActionId;
    }

    public ObjectiveAction ObjectiveAction { get; private set; }
    public Guid ObjectiveActionId { get; private set; }

    private Recommendation(string description, DateTime dueDate, Guid objectiveActionId,
        ObjectiveAction objectiveAction)
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

    public void SetStatus(Status newStatus)
    {
        this.Status = newStatus;
    }

    public static Result<Recommendation> Create(
        string description,
        DateTime dueDate,
        string problem,
        string? aditionalFindings,
        string? cause,
        string? consequence,
        string recommendationDescription,
        ObjectiveAction objectiveAction,
        Guid objectiveActionId)
    {
        //TODO : Add validation logic here
        return Result<Recommendation>.Success(new Recommendation(
            description,
            dueDate,
            problem,
            aditionalFindings,
            cause,
            consequence,
            recommendationDescription,
            objectiveAction,
            objectiveActionId));
    }
}

public enum Status
{
    Implemented,
    PartiallyImplemented,
    NotImplemented,
}