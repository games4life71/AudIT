using Frontend.EntityDtos.AuditMission;

namespace Frontend.EntityViewModels.Fiap;

public class BaseObjActionFiapViewmodel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid AuditMissionId { get; set; }

    public BaseAuditMissionDto AuditMission { get; set; }

    public Guid ObjectiveActionId { get; set; }

    public DateTime AuditedPeriodStart { get; set; }

    public DateTime AuditedPeriodEnd { get; set; }

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string Recommendation { get; set; }
}