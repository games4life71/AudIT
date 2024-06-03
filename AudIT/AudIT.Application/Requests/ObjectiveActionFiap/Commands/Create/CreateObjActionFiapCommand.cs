using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Create;

public class CreateObjActionFiapCommand : IRequest<BaseDTOResponse<BaseObjActionFiapDto>>
{
    public string Name { get; set; }

    public Guid AuditMissionId { get; set; }

    public Guid ObjectiveActionId { get; set; }

    public DateTime AuditedPeriodStart { get; set; }

    public DateTime AuditedPeriodEnd { get; set; }

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string Recommendation { get; set; }

    public CreateObjActionFiapCommand(string name, Guid auditMissionId, Guid objectiveActionId,
        DateTime auditedPeriodStart, DateTime auditedPeriodEnd, string problem, string? aditionalFindings,
        string? cause, string? consequence, string recommendation)
    {
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
}