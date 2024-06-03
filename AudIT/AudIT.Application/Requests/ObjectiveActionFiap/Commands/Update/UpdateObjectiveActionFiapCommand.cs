using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Update;

public class UpdateObjectiveActionFiapCommand:IRequest<BaseDTOResponse<BaseObjActionFiapDto>>
{

    public Guid Id { get; set; }
    public string Name { get; set; }

    public DateTime AuditedPeriodStart { get; set; }

    public DateTime AuditedPeriodEnd { get; set; }

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string Recommendation { get; set; }

    public UpdateObjectiveActionFiapCommand(Guid id , string name, DateTime auditedPeriodStart, DateTime auditedPeriodEnd, string problem, string? aditionalFindings, string? cause, string? consequence, string recommendation)
    {
        Id = id;
        Name = name;
        AuditedPeriodStart = auditedPeriodStart;
        AuditedPeriodEnd = auditedPeriodEnd;
        Problem = problem;
        AditionalFindings = aditionalFindings;
        Cause = cause;
        Consequence = consequence;
        Recommendation = recommendation;
    }
}