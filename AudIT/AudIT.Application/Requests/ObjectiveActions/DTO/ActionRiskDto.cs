using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.ObjectiveActions.DTO;

public class ActionRiskDto
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Risk Risk { get; private set; }

    public int Probability { get; private set; }

    public int Impact { get; private set; }

    public ActionRiskDto(Guid id, string name, Risk risk, int probability, int impact, Guid objectiveActionId)
    {
        Id = id;
        Name = name;
        Risk = risk;
        Probability = probability;
        Impact = impact;
        ObjectiveActionId = objectiveActionId;
    }

    public Guid ObjectiveActionId { get; private set; }
}