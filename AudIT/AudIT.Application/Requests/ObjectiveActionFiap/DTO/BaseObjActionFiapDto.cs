using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;

public class BaseObjActionFiapDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid AuditMissionId { get; set; }

    public BaseAuditMissionDto AuditMission { get; set; }

    public Guid ObjectiveActionId { get; set; }

    // public ObjectiveAction ObjectiveAction { get; set; }

    public DateTime AuditedPeriodStart { get; set; }

    public DateTime AuditedPeriodEnd { get; set; }

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string Recommendation { get; set; }
}