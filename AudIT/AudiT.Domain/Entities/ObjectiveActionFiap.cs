using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

/// <summary>
/// This class models the FIAP of an objective action
/// It contains the problem identified , the cause  and the action to be taken
/// It is completed after an objective action is analyzed
/// After it's completion, a recommendation is created automatically
/// </summary>
public class ObjectiveActionFiap : AuditableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid AuditMissionId { get; set; }

    public AuditMission AuditMission { get; set; }

    public Guid ObjectiveActionId { get; set; }

    public ObjectiveAction ObjectiveAction { get; set; }

    public DateTime AuditedPeriodStart { get; set; }

    public DateTime AuditedPeriodEnd { get; set; }

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string Recommendation { get; set; }


    private ObjectiveActionFiap(string name, Guid auditMissionId, Guid objectiveActionId,
        DateTime auditedPeriodStart, DateTime auditedPeriodEnd, string problem, string recommendation,
        string aditionalFindings = "empty", string cause = "empty", string consequence = "empty")
    {
        Id = Guid.NewGuid();
        Name = name;
        AuditMissionId = auditMissionId;
        ObjectiveActionId = objectiveActionId;
        AuditedPeriodStart = auditedPeriodStart;
        AuditedPeriodEnd = auditedPeriodEnd;
        Problem = problem;
        AditionalFindings = aditionalFindings;
        Cause = cause;
        Consequence = consequence;
        Recommendation = recommendation;
    }


    public ObjectiveActionFiap()
    {
    }


    public static Result<ObjectiveActionFiap> Create(string name, Guid auditMissionId,
        Guid objectiveActionId, DateTime auditedPeriodStart, DateTime auditedPeriodEnd,
        string problem, string recommendation, string aditionalFindings = "empty", string cause = "empty",
        string consequence = "empty")
    {
        //TODO : Add validation logic here

        return Result<ObjectiveActionFiap>.Success(new ObjectiveActionFiap(
            name,
            auditMissionId,
            objectiveActionId,
            auditedPeriodStart,
            auditedPeriodEnd,
            problem,
            recommendation,
            aditionalFindings,
            cause,
            consequence
        ));
    }
}