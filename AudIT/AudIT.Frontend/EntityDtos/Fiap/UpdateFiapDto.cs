namespace Frontend.EntityDtos.Fiap;

public class UpdateFiapDto
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

    public UpdateFiapDto(Guid id, string name, DateTime auditedPeriodStart, DateTime auditedPeriodEnd, string problem,
        string? aditionalFindings, string? cause, string? consequence, string recommendation)
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