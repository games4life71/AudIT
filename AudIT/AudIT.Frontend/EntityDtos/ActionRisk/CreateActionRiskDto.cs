namespace Frontend.EntityDtos.ActionRisk;

public class CreateActionRiskDto
{
    public Guid objectiveActionId { get; set; }

    public string actionRiskName { get; set; }

    public int Risk { get; set; }

    public int Probability { get; set; }

    public int Impact { get; set; }
}