using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.ObjectiveActions.DTO;

public class ObjActionWithRisksDto
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public List<ActionRisk> ActionRisks { get; private set; }

    public List<string> controaleInterneExistente { get; set; } = [];

    public List<string> controaleInterneAsteptate { get; set; } = [];

    public Guid ObjectiveId { get; set; }

    public ObjActionWithRisksDto(Guid id, string name, List<ActionRisk> actionRisks)
    {
        Id = id;
        Name = name;
        ActionRisks = actionRisks;
    }
}