namespace Frontend.EntityDtos.ActionRisk;

public class UpdateActionRiskDto
{
    public Guid actionRiskId { get; set; }

    public string Name { get; set; }

    public int Risk { get; set; }

    public int Probability { get; set; }

    public int Impact { get; set; }

    public UpdateActionRiskDto(Guid actionRiskId, string name, int risk, int probability, int impact)
    {
        this.actionRiskId = actionRiskId;
        Name = name;
        Risk = risk;
        Probability = probability;
        Impact = impact;
    }
}