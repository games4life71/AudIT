using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.ObjectiveActions.DTO;

public class ObjActionWithRisksDto
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public List<ActionRisk> Risks { get; private set; }


    public ObjActionWithRisksDto(Guid id, string name, List<ActionRisk> risks)
    {
        Id = id;
        Name = name;
        Risks = risks;
    }
}